using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FiscalManagementSystem.ProductCatagories.Dto;
using FiscalManagementSystem.Vehicles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.ProductCatagories
{
    public interface IProductCatagoryAppService
    {
        Task<PagedResultDto<GetProductCatagoryForViewDto>> GetAll(GetAllProductCatagoryInput input);
    }
}
