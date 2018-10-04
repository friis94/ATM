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
        List<ISeparation> separations { get; set; }

        void Update(object source, SeparationChangedEventArgs args);

        
    }
}
