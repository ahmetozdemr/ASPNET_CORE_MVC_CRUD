using ASPNET_CORE_MVC_CRUD.Data;
using ASPNET_CORE_MVC_CRUD.Models.CustomerModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_CORE_MVC_CRUD.Controllers
{
    public class CustomersController : Controller
    {

        private readonly DataContext _dataContext;

        public CustomersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _dataContext.Customers.ToListAsync();

            return View(customers);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string value)
        {

            var customers = await _dataContext.Customers.ToListAsync();
            if (!string.IsNullOrEmpty(value))
            {
                customers = customers.Where(c => c.Name.ToUpper().Contains(value.ToUpper())).ToList();
            }

            return View(customers);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCutomerViewModel addCutomerViewModel)
        {
            var customer = new Customer()
            {
                Id = Guid.NewGuid(),
                Name = addCutomerViewModel.Name,
                Email = addCutomerViewModel.Email,
                Phone = addCutomerViewModel.Phone,
                Address = addCutomerViewModel.Address,
                DateOfBirth = addCutomerViewModel.DateOfBirth
            };
            await _dataContext.Customers.AddAsync(customer);
            await _dataContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var customer = await _dataContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer != null)
            {
                var viewModel = new UpdateCustomerViewModel()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address = customer.Address,
                    DateOfBirth = customer.DateOfBirth
                };
                return await Task.Run(() => View("Update", viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCustomerViewModel model)
        {
            var customer = await _dataContext.Customers.FindAsync(model.Id);
            if (customer != null)
            {
                customer.Name = model.Name;
                customer.Email = model.Email;
                customer.Phone = model.Phone;
                customer.Address = model.Address;
                customer.DateOfBirth = model.DateOfBirth;

                await _dataContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _dataContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer != null)
            {
                var viewModel = new DeleteCustomerViewModel()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address = customer.Address,
                    DateOfBirth = customer.DateOfBirth
                };
                return await Task.Run(() => View("Delete", viewModel));

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCustomerViewModel model)
        {
            var customer = await _dataContext.Customers.FindAsync(model.Id);
            if (customer != null)
            {
                _dataContext.Customers.Remove(customer);
                await _dataContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}
