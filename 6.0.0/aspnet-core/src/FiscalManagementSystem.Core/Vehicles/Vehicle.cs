using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Vehicles
{
   
	[Table("Vehicles")]
	public class Vehicle : Entity
	{
		[Key] [Column("VehicleId")] public override int Id { get; set; }
        public virtual string CarName { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Model { get; set; }
        public virtual string Registration { get; set; }
        public virtual string Plate { get; set; }
        public virtual string Number { get; set; }
        public virtual bool IsActive { get; set; }

    }

}
