using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.ProductCatagories.Dto
{
    public class GetAllProductInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public int ProductCatagoryId { get; set; }
    }
}
