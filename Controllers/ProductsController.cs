using Microsoft.AspNetCore.Mvc;

namespace ASPNET_CORE_MVC_CRUD.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
