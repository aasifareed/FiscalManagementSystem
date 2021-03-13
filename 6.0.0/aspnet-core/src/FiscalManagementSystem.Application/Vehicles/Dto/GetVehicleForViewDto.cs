using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Vehicles.Dto
{
    public class GetVehicleForViewDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Plate { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }
    }
}
