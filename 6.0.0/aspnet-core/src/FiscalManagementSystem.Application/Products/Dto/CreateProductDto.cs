using Abp.AutoMapper;
using Abp.Runtime.Validation;
using FiscalManagementSystem.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.ProductCatagories.Dto
{
    [AutoMapTo(typeof(Product))]
    public class CreateProductDto 
    {
        public virtual string Name { get; set; }
        public virtual string Quantity { get; set; }
        public virtual string Price { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Color { get; set; }
        public int ProductCatagoryId { get; set; }


    }
}
