using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Unit.Test
{
    class FakeATMController : IController
    {

        private ISeparationDetector _separationDetector;
        private List<IVehicle> vehicles;
        private List<ISeparation> _separations;



        public FakeATMController()
        {

            this._separationDetector = new SeparationDetector();
            _separationDetector.SeparationEvent += Update;

        }




        public void Update(object source, SeparationChangedEventArgs args)
        {

            this._separations = args.separations;

        }


    }
}
