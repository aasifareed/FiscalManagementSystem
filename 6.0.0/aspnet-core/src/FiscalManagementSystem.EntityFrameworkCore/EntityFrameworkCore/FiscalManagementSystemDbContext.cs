using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FiscalManagementSystem.Authorization.Roles;
using FiscalManagementSystem.Authorization.Users;
using FiscalManagementSystem.MultiTenancy;
using FiscalManagementSystem.Vehicles;
using FiscalManagementSystem.ProductCatagories;
using FiscalManagementSystem.ProductCatagoriesPictures;
using FiscalManagementSystem.Products;
using FiscalManagementSystem.ProductPictures;
using FiscalManagementSystem.Orders;
using FiscalManagementSystem.OrderProducts;
using FiscalManagementSystem.Sales;

namespace FiscalManagementSystem.EntityFrameworkCore
{
    public class FiscalManagementSystemDbContext : AbpZeroDbContext<Tenant, Role, User, FiscalManagementSystemDbContext>
    {
        public  DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ProductCatagory> ProductCatagories{ get; set; }
        public DbSet<ProductCatagoryPictures> ProductCatagoryPictures{ get; set; }
        public DbSet<Order> orders{ get; set; }
        public DbSet<OrderProduct> orderProducts{ get; set; }
        public DbSet<Sale> sales{ get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }

        /* Define a DbSet for each entity of the application */

        public FiscalManagementSystemDbContext(DbContextOptions<FiscalManagementSystemDbContext> options)
            : base(options)
        {
        }

    }
}
