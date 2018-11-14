using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Exception = System.Exception;
using Version = System.Version;

namespace ATM
{
    public class Decoder : IDecoder
    {
       
        public List<IVehicle> Decode(List<string> transponderData)
        {
            List<IVehicle> vehicleList = new List<IVehicle>();

            foreach (var data in transponderData)
            {
                IVehicle vehicle = new Airplane();
                string[] dataSplit = data.Split(';');
                vehicle.Tag = dataSplit[0];

                try
                {
                    vehicle.XCoordinate = Int32.Parse(dataSplit[1], CultureInfo.InvariantCulture);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                try
                {
                    vehicle.YCoordinate = Int32.Parse(dataSplit[2], CultureInfo.InvariantCulture);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                try
                {
                    vehicle.Altitude = Int32.Parse(dataSplit[3], CultureInfo.InvariantCulture);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                try
                {
                    vehicle.Timestamp = DateTime.ParseExact(dataSplit[4], "yyyyMMddHHmmssFFF", null);

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                vehicleList.Add(vehicle);

            }
            return vehicleList;
        }
    }
}
