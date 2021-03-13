using Abp.Domain.Entities.Auditing;
using FiscalManagementSystem.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.OrderProducts
{
    public class OrderProduct : FullAuditedEntity<int>
    {
        [Column("OrderProductId")]
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
