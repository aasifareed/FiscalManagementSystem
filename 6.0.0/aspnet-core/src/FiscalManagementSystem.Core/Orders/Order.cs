using Abp.Domain.Entities.Auditing;
using FiscalManagementSystem.OrderProducts;
using FiscalManagementSystem.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Orders
{
    public class Order : FullAuditedEntity<int>
    {
        [Column("OrderId")]
        public override int  Id { get; set; }
        public string Name { get; set; }
        public ICollection<OrderProduct> OrderProducts{ get; set; }
        public ICollection<Sale> sales{ get; set; }
    }
}
