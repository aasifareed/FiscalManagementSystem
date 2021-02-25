using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using FiscalManagementSystem.Configuration;
using FiscalManagementSystem.Web;

namespace FiscalManagementSystem.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class FiscalManagementSystemDbContextFactory : IDesignTimeDbContextFactory<FiscalManagementSystemDbContext>
    {
        public FiscalManagementSystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FiscalManagementSystemDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            FiscalManagementSystemDbContextConfigurer.Configure(builder, configuration.GetConnectionString(FiscalManagementSystemConsts.ConnectionStringName));

            return new FiscalManagementSystemDbContext(builder.Options);
        }
    }
}
