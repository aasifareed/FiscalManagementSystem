using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FiscalManagementSystem.Authorization;

namespace FiscalManagementSystem
{
    [DependsOn(
        typeof(FiscalManagementSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FiscalManagementSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FiscalManagementSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FiscalManagementSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
