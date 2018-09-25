using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ATMController
    {

        /*public event EventHandler SeperationEventHandler;
        private ISeperationDetector seperationDetector;
        */


        public ATMController()
        {
            /*
            this.seperationDetector = new SeperationDetector();
            seperationDetector.SeperationEvent += Update;
            */
        }




        public void Update(object source, SeperationChangedEventArgs args)
        {
            //args.seperations;
        }

    }
}
