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
        public List<ISeparation> seperations { get; set; }
    }

    public interface ISeparationDetector
    {
        event EventHandler SeperationEvent;
        void Update(List<IVehicle> vehicles);

        List<ISeparation> CalculateSeperations(List<IVehicle> vehicles);
    }
}
