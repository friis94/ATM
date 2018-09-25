using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{

    public interface ISeperation
    {
        IVehicle VehicleA { get; set; }
        IVehicle VehicleB { get; set; }
        DateTime TimeStamp { get; set; }
    }
}
