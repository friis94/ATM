using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Seperation : ISeperation
    {
        public IVehicle VehicleA { get; set; }
        public IVehicle VehicleB { get; set; }
        public DateTime TimeStamp { get; set; }

        public Seperation(IVehicle vehicleA, IVehicle vehicleB, DateTime timeStamp)
        {
            VehicleA = vehicleA;
            VehicleB = vehicleB;
            TimeStamp = timeStamp;
        }
    }
}
