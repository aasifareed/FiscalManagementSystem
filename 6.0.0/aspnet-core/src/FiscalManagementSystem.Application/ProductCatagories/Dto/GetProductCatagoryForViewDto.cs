using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.ProductCatagories.Dto
{
    public class GetProductCatagoryForViewDto:Entity<int>
    {
        public string CatagoryNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual Byte[] fileInByte { get; set; }
        public virtual string ImagePath { get; set; }
    }
}
