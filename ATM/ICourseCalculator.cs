using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ICourseCalculator
    {
        List<IVehicle> CalculateCourse(List<IVehicle> newVehicles, List<IVehicle> oldVehicles);
    }
}
