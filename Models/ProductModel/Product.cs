namespace ASPNET_CORE_MVC_CRUD.Models.ProductModel
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
