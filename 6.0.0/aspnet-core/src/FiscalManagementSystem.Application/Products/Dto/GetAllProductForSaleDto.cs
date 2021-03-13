using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Products.Dto
{
    public class GetAllProductForSaleDto:Entity<int>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
        public byte[] ImageInByte { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public DateTime? Date { get; set; }
    }
}
