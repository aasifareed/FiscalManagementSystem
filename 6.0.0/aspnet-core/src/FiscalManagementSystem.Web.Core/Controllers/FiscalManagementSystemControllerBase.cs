using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace FiscalManagementSystem.Controllers
{
    public abstract class FiscalManagementSystemControllerBase: AbpController
    {
        protected FiscalManagementSystemControllerBase()
        {
            LocalizationSourceName = FiscalManagementSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
