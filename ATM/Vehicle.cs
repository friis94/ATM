using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Vehicle :IVehicle
    {
        public string Tag { get; set; }
        public int Xcoordinate { get; set; }
        public int Ycoordinate { get; set; }
        public int Altitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
