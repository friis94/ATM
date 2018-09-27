using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IController
    {

        List<IVehicle> vehicles { get; set; }

        ISeparationDetector separationDetector { get; set; }
        void Update(object source, SeparationChangedEventArgs args);

        List<ISeparation> separations { get; set; }
    }
}
