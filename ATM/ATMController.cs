using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ATMController : IController
    {

        public ISeparationDetector separationDetector { get; set; }
        public List<IVehicle> vehicles { get; set; }
        public List<ISeparation> separations { get; set; }



        public ATMController()
        {
            
            this.separationDetector = new SeparationDetector();
            separationDetector.SeparationEvent += Update;
            
        }




        public void Update(object source, SeparationChangedEventArgs args)
        {
            
        }

    }
}
