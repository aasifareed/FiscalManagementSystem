using Abp.Domain.Entities.Auditing;
using FiscalManagementSystem.ProductCatagories;
using FiscalManagementSystem.ProductPictures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Products
{
    [Table("Products")]
    public class Product : FullAuditedEntity
    {
        [Key]
        [Column("ProductId")]
        public override int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Quantity { get; set; }
        public virtual int Price { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Color { get; set; }
        public virtual string size { get; set; }
        public virtual DateTime? date { get; set; }

        public int ProductCatagoryId { get; set; }
        public virtual ProductCatagory ProductCatagory { get; set; }

        public virtual ICollection<ProductPicture> ProductPictures{ get; set; }
    }
}
