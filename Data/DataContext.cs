using System.Collections.Generic;
using ASPNET_CORE_MVC_CRUD.Models.CustomerModel;
using ASPNET_CORE_MVC_CRUD.Models.EmployeeModel;
using ASPNET_CORE_MVC_CRUD.Models.ProductModel;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_CORE_MVC_CRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=AHMET-PC;Database=MvcCoreDemoDb;Trusted_Connection=True;TrustServerCertificate =true;");
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
