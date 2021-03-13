using Abp.Domain.Entities.Auditing;
using FiscalManagementSystem.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.ProductPictures
{
    [Table("ProductPictures")]
    public class ProductPicture : FullAuditedEntity
    {
        [Key]
        [Column("ProductPictureId")]
        public override int Id { get; set; }
        public virtual byte[] file { get; set; }
        public virtual bool? IsDefault { get; set; }
        public virtual string Name { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
