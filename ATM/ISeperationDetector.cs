using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class SeperationChangedEventArgs : EventArgs
    {
        public List<ISeperation> seperations { get; set; }
    }

    public interface ISeperationDetector
    {
        event EventHandler SeperationEvent;
        void Update(List<IVehicle> vehicles);
    }
}
