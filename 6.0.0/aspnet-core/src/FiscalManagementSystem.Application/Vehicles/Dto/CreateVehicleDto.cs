using Abp.AutoMapper;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Vehicles.Dto
{
    [AutoMapTo(typeof(Vehicle))]
    public class CreateVehicleDto 
    {
        public virtual string CarName { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Model { get; set; }
        public virtual string Registration { get; set; }
        public virtual string Plate { get; set; }
        public virtual string Number { get; set; }
        public virtual bool IsActive { get; set; }

    }

}
