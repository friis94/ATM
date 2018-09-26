using System;
using System.Collections.Generic;
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
        private List<IVehicle> vehicleList = new List<IVehicle>();
       // private IVehicle vehicle = new IVehicle();

        public List<IVehicle> Decode(List<string> transponderData)
        {
            // ATR423;39045;12932;14000;20151006213456789
            IVehicle vehicle = new Vehicle();
            int indexStart = 0;
            int indexEnd = 0;
            foreach (var data in transponderData)
            {
                indexEnd = data.IndexOf(";", indexStart);
                if (indexEnd > 0)
                {
                    vehicle.Tag = data.Substring(indexStart, indexEnd);
                }
                
                indexStart = indexEnd + 1;
                indexEnd = data.IndexOf(";", indexStart);
                try
                {
                    vehicle.Xcoordinate = Int32.Parse(data.Substring(indexStart, indexEnd - indexStart));
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                

                indexStart = indexEnd + 1;
                indexEnd = data.IndexOf(";", indexStart);
                try
                {
                    vehicle.Ycoordinate = Int32.Parse(data.Substring(indexStart, indexEnd - indexStart));
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                

                
                indexStart = indexEnd + 1;
                indexEnd = data.IndexOf(";", indexStart);
                try
                {
                    vehicle.Altitude = Int32.Parse(data.Substring(indexStart, indexEnd - indexStart));
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
                /*
                indexStart = indexEnd + 1;
                try
                {
                    vehicle.Timestamp = DateTime.Parse(data.Substring(indexStart));
                }
                catch (DataMisalignedException e)
                {
                    Console.WriteLine(e);
                    throw;
                }*/
                
                vehicleList.Add(vehicle);
            }


            return vehicleList;
        }
    }
}
