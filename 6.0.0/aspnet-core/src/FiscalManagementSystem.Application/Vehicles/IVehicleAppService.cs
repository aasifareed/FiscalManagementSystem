using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FiscalManagementSystem.Vehicles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Vehicles
{
    public interface IVehicleAppService
    {
        Task<PagedResultDto<GetVehicleForViewDto>> GetAll(GetAllVehicleInput input);
    }
}
