using Abp.Domain.Entities.Auditing;
using FiscalManagementSystem.ProductCatagoriesPictures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.ProductCatagories
{
        [Table("ProductCatagory")]
        public class ProductCatagory : FullAuditedEntity<int>
        {
            [Key]
            [Column("ProductCatagoryId")]
            public override int Id { get; set; }
            public virtual string CatagoryNumber { get; set; }
            public virtual string Name { get; set; }
            public virtual string Description { get; set; }
            public virtual bool IsActive { get; set; }

        public virtual ICollection<ProductCatagoryPictures> ProductCatagoryPictures { get; set; }

        }
}
