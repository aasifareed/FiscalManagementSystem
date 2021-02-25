using System.Threading.Tasks;
using Abp.Application.Services;
using FiscalManagementSystem.Sessions.Dto;

namespace FiscalManagementSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
