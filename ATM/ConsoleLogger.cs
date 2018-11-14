﻿using System;
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
            _writer.WriteLine(" ------------------------------------ Separation Event -----------------------------------");
            foreach (var s in separations)
            {
                string timeStampString = s.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                _writer.WriteLine($"Separation between {s.VehicleA.Tag} and {s.VehicleB.Tag} @ {timeStampString}");
            }

            _writer.WriteLine("------------------------------------------------------------------------------------------");
        }

        public void SetVehicles(List<IVehicle> vehicles)
        {
            _writer.WriteLine(" ------------------------------- Airplanes in the airspace -------------------------------");
            foreach (var v in vehicles)
            {
                _writer.WriteLine($"{v.Tag} , Coordinate(x, y): ({v.XCoordinate}, {v.YCoordinate}), Altitude: {v.Altitude}, Velocity: {v.Velocity}, Compass Course: {v.Course}");
            }

            _writer.WriteLine("------------------------------------------------------------------------------------------");
        }

        public void SetEnterTracks(List<IVehicle> vehicles)
        {   
                _writer.WriteLine(" ------------------------------- Airplanes Entered airspace -------------------------------");
                foreach (var v in vehicles)
                {
                    string timeStampString = v.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                    _writer.WriteLine($"{v.Tag} at time @ {timeStampString}");

                }
                _writer.WriteLine("------------------------------------------------------------------------------------------");
        }

        public void SetExitTracks(List<IVehicle> vehicles)
        {
            if (vehicles.Count > 0)
            {
                _writer.WriteLine(" ------------------------------- Airplanes Entered airspace -------------------------------");
                foreach (var v in vehicles)
                {
                    string timeStampString =
                        v.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                    _writer.WriteLine($"{v.Tag} at time @ {timeStampString}");

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
