using Abp.Domain.Entities.Auditing;
using FiscalManagementSystem.OrderProducts;
using FiscalManagementSystem.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Sales
{
    public class Sale : FullAuditedEntity<int>
    {
        [Column("SaleId")]
        public override int Id { get; set; }
        public DateTime? date { get; set; }
        public int totalprice { get; set; }
        public int? discount { get; set; }
        
        public int OrderId { get; set; }
        public Order Order{ get; set; }
    }
}
