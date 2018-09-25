using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ATMController
    {

        public event EventHandler SeperationEventHandler;

        void Update(List<IVehicle> vehicles)
        {

        }


        public void Update(object source, SeperationChangedEventArgs args)
        {
            args.seperations;
        }

    }
}
