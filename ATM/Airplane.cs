using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{

    public class Airplane : IVehicle
    {
        public string Tag { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int Altitude { get; set; }
        public int Velocity { get; set; }
        public int Course { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
