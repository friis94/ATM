using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    class SeparationDetectorUnitTest
    {

        [Test]
        void DetectSeperationEvent_AddTwoVehiclesOnCollision_UpdateIsCalled()
        {
            //Arrange

            IController controller  = new FakeATMController();
            ISeparationDetector _uut = new SeparationDetector();
            List<IVehicle> vehicles = new List<IVehicle>();

            //Adding two colliding airplanes
            Airplane vehicleA = new Airplane();
            vehicleA.Altitude = 100;
            vehicleA.Xcoordinate = 100;
            vehicleA.Ycoordinate = 100;

            Airplane vehicleB = new Airplane();
            vehicleA.Altitude = 99;
            vehicleA.Xcoordinate = 99;
            vehicleA.Ycoordinate = 99;

            vehicles.Add(vehicleA);
            vehicles.Add(vehicleB);


            
            //Act



            //Assert
        }

    }
}
