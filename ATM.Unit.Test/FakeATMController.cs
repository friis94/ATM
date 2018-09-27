using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Unit.Test
{
    public class FakeATMController : IController
    {

        public ISeparationDetector separationDetector { get; set; }
        public List<IVehicle> vehicles { get; set; }
        public List<ISeparation> separations { get; set; }



        public FakeATMController()
        {

            this.separationDetector = new SeparationDetector();
            separationDetector.SeparationEvent += Update;

        }



        public void Update(object source, SeparationChangedEventArgs args)
        {

            this.separations = args.separations;

        }


    }
}
