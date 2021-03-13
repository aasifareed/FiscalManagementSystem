using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Products.Dto
{
    public class GetProductCatagoryForDropDownDto 
    {
        public int ProductCatagoryId { get; set; }
        public  string Name { get; set; }
    }
}
