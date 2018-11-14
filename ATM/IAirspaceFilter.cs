using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IAirspaceFilter
    {
        void SetAirSpace(int xMin, int xMax, int yMin, int yMax, int altitudeMin, int altitudeMax);
        List<IVehicle> FilterVehicles(List<IVehicle> vehicles);
    }
}
