using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class AirspaceFilter : IAirspaceFilter
    {
        private int _xmin;
        private int _xmax;
        private int _ymin;
        private int _ymax;
        private int _altitudemin;
        private int _altitudemax;


        public void SetAirSpace(int xmin, int xmax, int ymin, int ymax, int altitudemin, int altitudemax)
        {
            _xmin = xmin;
            _xmax = xmax;
            _ymin = ymin;
            _ymax = ymax;
            _altitudemin = altitudemin;
            _altitudemax = altitudemax;
        }

        public List<IVehicle> FilterVehicles(List<IVehicle> vehicles)
        {
            for (int i = vehicles.Count; i >= 0; i++)
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
