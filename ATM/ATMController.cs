using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ATMController : IController
    {
        
        private ISeparationDetector _separationDetector;
        private List<IVehicle> vehicles;
        private List<ISeparation> seperations;
        


        public ATMController()
        {
            
            this._separationDetector = new SeparationDetector();
            _separationDetector.SeparationEvent += Update;
            
        }




        public void Update(object source, SeparationChangedEventArgs args)
        {
            


        }

    }
}
