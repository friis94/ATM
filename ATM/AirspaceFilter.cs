using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class AirspaceFilter : IAirspaceFilter
    {
        private int _xmin;
        private int _xmax;
        private int _ymin;
        private int _ymax;
        private int _altitudemin;
        private int _altitudemax;


        public void SetAirSpace(int xMin, int xMax, int yMin, int yMax, int altitudeMin, int altitudeMax)
        {
            _xmin = xMin;
            _xmax = xMax;
            _ymin = yMin;
            _ymax = yMax;
            _altitudemin = altitudeMin;
            _altitudemax = altitudeMax;
        }

        public List<IVehicle> FilterVehicles(List<IVehicle> vehicles)
        {
            for (int i = vehicles.Count-1; i >= 0; i--)
            {
                IVehicle vehicle = vehicles[i];

                if (vehicle.Xcoordinate < _xmin || vehicle.Xcoordinate > _xmax ||
                    vehicle.Ycoordinate < _ymin || vehicle.Ycoordinate > _ymax ||
                    vehicle.Altitude < _altitudemin || vehicle.Altitude > _altitudemax)
                {
                    vehicles.RemoveAt(i);
                }
            }

            return vehicles;
        }
    }
}
