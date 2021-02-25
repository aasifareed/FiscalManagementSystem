using Abp.Authorization;
using FiscalManagementSystem.Authorization.Roles;
using FiscalManagementSystem.Authorization.Users;

namespace FiscalManagementSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
