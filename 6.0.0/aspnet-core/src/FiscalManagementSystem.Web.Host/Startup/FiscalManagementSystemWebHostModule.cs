using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FiscalManagementSystem.Configuration;

namespace FiscalManagementSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(FiscalManagementSystemWebCoreModule))]
    public class FiscalManagementSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FiscalManagementSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FiscalManagementSystemWebHostModule).GetAssembly());
        }
    }
}
