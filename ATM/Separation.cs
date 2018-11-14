using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Separation : ISeparation
    {

        public Separation(IVehicle vehicleA, IVehicle vehicleB, DateTime timestamp)
        {
            
            this.Timestamp = timestamp;
            this.VehicleA = vehicleA;
            this.VehicleB = vehicleB;

        }
        
        public IVehicle VehicleA { get; set; }
        public IVehicle VehicleB { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
