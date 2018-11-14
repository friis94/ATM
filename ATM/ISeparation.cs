using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{

    public interface ISeparation
    {
        IVehicle VehicleA { get; set; }
        IVehicle VehicleB { get; set; }
        DateTime Timestamp { get; set; }
    }
}
