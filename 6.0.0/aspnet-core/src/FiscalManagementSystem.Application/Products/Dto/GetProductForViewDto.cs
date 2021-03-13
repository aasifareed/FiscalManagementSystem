using Abp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.ProductCatagories.Dto
{
    public class GetProductForViewDto:Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual int Quantity { get; set; }
        public virtual int Price { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Color { get; set; }
        public int ProductCatagoryId { get; set; }
        public string ProductCatagory { get; set; }
        public virtual Byte[] fileInByte { get; set; }
        public virtual string ImagePath{ get; set; }
        
    }
}
