using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FiscalManagementSystem.Authorization.Roles;
using FiscalManagementSystem.Authorization.Users;
using FiscalManagementSystem.MultiTenancy;

namespace FiscalManagementSystem.EntityFrameworkCore
{
    public class FiscalManagementSystemDbContext : AbpZeroDbContext<Tenant, Role, User, FiscalManagementSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public FiscalManagementSystemDbContext(DbContextOptions<FiscalManagementSystemDbContext> options)
            : base(options)
        {
        }
    }
}
