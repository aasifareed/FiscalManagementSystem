using System.Threading.Tasks;
using Abp.Application.Services;
using FiscalManagementSystem.Authorization.Accounts.Dto;

namespace FiscalManagementSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
