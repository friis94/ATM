using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class SeparationChangedEventArgs : EventArgs
    {
        public List<ISeparation> Separations { get; set; }
    }

    public interface ISeparationDetector
    {
        event EventHandler<SeparationChangedEventArgs> SeparationEvent;

        void CalculateSeparations(List<IVehicle> vehicles);
    }
}
