using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IVehicle
    {
        string Tag { get; set; }
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }
        int Altitude { get; set; }
        int Velocity { get; set; }
        int Course { get; set; }

        DateTime Timestamp { get; set; }

    }
}
