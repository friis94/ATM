using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConsoleLogger : IConsoleLogger
    {
        private IConsoleWriter _writer;
        public ConsoleLogger(IConsoleWriter writer)
        {
            _writer = writer;
        }

        
        public void SetSeparations(List<ISeparation> separations)
        {
            if (separations == null)
            {
                throw new ArgumentNullException("separations");
            }

            _writer.WriteLine(" ------------------------------------ Separation Event -----------------------------------");
            foreach (var s in separations)
            {
                string timeStampString = s.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                _writer.WriteLine(String.Format(CultureInfo.CurrentCulture, "Separation between {0} and {1} @ {2}", s.VehicleA.Tag, s.VehicleB.Tag, timeStampString));
            }

            _writer.WriteLine("------------------------------------------------------------------------------------------");
        }

        public void SetVehicles(List<IVehicle> vehicles)
        {
            if (vehicles == null)
            {
                throw new ArgumentNullException("vehicles");
            }

            _writer.WriteLine(" ------------------------------- Airplanes in the airspace -------------------------------");
            foreach (var v in vehicles)
            {
                _writer.WriteLine(String.Format(CultureInfo.CurrentCulture, "{0} , Coordinate(x, y): ({1}, {2}), Altitude: {3}, Velocity: {4}, Compass Course: {5}", v.Tag, v.XCoordinate, v.YCoordinate, v.Altitude, v.Velocity, v.Course));
            }

            _writer.WriteLine("------------------------------------------------------------------------------------------");
        }

        public void SetEnterTracks(List<IVehicle> vehicles)
        {
            if (vehicles == null)
            {
                throw new ArgumentNullException("vehicles");
            }

            _writer.WriteLine(" ------------------------------- Airplanes Entered airspace -------------------------------");
                foreach (var v in vehicles)
                {
                    string timeStampString = v.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                    _writer.WriteLine(String.Format(CultureInfo.CurrentCulture, "{0} at time @ {1}", v.Tag, timeStampString));
                }
                _writer.WriteLine("------------------------------------------------------------------------------------------");
        }

        public void SetExitTracks(List<IVehicle> vehicles)
        {
            if (vehicles == null)
            {
                throw new ArgumentNullException("vehicles");
            }

            if (vehicles.Count > 0)
            {
                _writer.WriteLine(" ------------------------------- Airplanes Exited airspace -------------------------------");
                foreach (var v in vehicles)
                {
                    string timeStampString =
                        v.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                    _writer.WriteLine(String.Format(CultureInfo.CurrentCulture, "{0} at time @ {1}", v.Tag, timeStampString));

                }
                _writer.WriteLine("------------------------------------------------------------------------------------------");
            }
        }

        public void ClearConsole()
        {
            _writer.Clear();
        }
    }
}
