using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Vehicles.Dto
{
    public class GetAllVehicleInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
