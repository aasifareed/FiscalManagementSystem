using Abp.Domain.Entities.Auditing;
using FiscalManagementSystem.ProductCatagories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.ProductCatagoriesPictures
{

    [Table("ProductCatagoryPictures")]
    public class ProductCatagoryPictures : FullAuditedEntity
    {
        [Key]
        [Column("ProductCatagoryPictureId")]
        public override int Id { get; set; }
        public virtual byte[] file { get; set; }
        public virtual bool? IsDefault { get; set; }
        public virtual string Name { get; set; }

        public virtual int ProductCatagoryId { get; set; }

        public virtual ProductCatagory ProductCatagory{ get; set; }
    }
}
