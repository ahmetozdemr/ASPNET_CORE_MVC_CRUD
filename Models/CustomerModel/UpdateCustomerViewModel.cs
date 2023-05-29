namespace ASPNET_CORE_MVC_CRUD.Models.CustomerModel
{
    public class UpdateCustomerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
