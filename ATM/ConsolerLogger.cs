using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConsolerLogger : IConsoleLogger
    {
        public void SetSeparations(List<ISeparation> separations)
        {
            Console.WriteLine(" ------------------------------------ Separation Event -----------------------------------");
            foreach (var s in separations)
            {
                string timeStampString = s.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                Console.WriteLine($"Separation between {s.VehicleA.Tag} and {s.VehicleB.Tag} @ {timeStampString}");
            }

            Console.WriteLine("------------------------------------------------------------------------------------------");
        }

        public void SetVehicles(List<IVehicle> vehicles)
        {
            Console.WriteLine(" ------------------------------- Airplanes in the airspace -------------------------------");
            foreach (var v in vehicles)
            {
                string timeStampString = v.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                Console.WriteLine($"{v.Tag} , Coordinate(x, y): ({v.Xcoordinate}, {v.Ycoordinate}), Altitude: {v.Altitude}, Velocity: {v.velocity}, Compass course: {v.course}");
            }

            Console.WriteLine("------------------------------------------------------------------------------------------");
        }
    }
}
