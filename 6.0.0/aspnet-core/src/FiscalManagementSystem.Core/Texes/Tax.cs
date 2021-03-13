using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Texes
{
    public class Tax : FullAuditedEntity
    {
        [Key]
        [Column("TaxId")]
        public override int Id { get; set; }
        public virtual int ProductCatagoryId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual string TaxRate { get; set; }
    }
}
