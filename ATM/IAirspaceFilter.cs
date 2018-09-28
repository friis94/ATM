using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    interface IAirspaceFilter
    {
        void SetAirSpace(int xmin, int xmax, int ymin, int ymax, int altitudemin, int altitudemax);
        List<IVehicle> FilterVehicles(List<IVehicle> vehicles);

    }
}
