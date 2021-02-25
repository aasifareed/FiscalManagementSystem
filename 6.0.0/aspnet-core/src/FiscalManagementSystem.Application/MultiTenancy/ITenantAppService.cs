using Abp.Application.Services;
using FiscalManagementSystem.MultiTenancy.Dto;

namespace FiscalManagementSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

