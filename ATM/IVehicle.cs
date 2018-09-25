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
        int Xcoordinate { get; set; }
        int Ycoordinate { get; set; }
        int Altitude { get; set; }
        DateTime Timestamp { get; set; }

    }
}
