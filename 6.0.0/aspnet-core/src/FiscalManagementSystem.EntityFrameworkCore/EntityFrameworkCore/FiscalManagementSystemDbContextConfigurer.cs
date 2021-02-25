using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FiscalManagementSystem.EntityFrameworkCore
{
    public static class FiscalManagementSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FiscalManagementSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FiscalManagementSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
