using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace FiscalManagementSystem.Authorization
{
    public class FiscalManagementSystemAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Product, L("Product"));
            context.CreatePermission(PermissionNames.Pages_ProductCatagory, L("ProductCatagory"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, FiscalManagementSystemConsts.LocalizationSourceName);
        }
    }
}
