using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class SeperationDetector : ISeperationDetector
    {
        public event EventHandler SeperationEvent;
        public void Update(List<IVehicle> vehicles)
        {
            throw new NotImplementedException();
        }
    }
}
