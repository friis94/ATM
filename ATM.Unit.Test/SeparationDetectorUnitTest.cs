using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    class SeparationDetectorUnitTest
    {

        [Test]
        public void DetectSeperationEvent_AddTwoVehiclesOnCollision_EqualComparisonOfVehiclesIsTrue()
        {
            //Arrange

            IController controller  = new FakeATMController();
            ISeparationDetector _uut = controller.separationDetector;
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

            controller.vehicles = vehicles;

            //Act
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.That(controller.separations[0].VehicleA.Equals(vehicleA) && controller.separations[0].VehicleB.Equals(vehicleB));
            
        }


        [Test]
        public void DontDetectSeperationEvent_AddTwoVehiclesNotOnCollision_SeperationsInControllerIsNull()
        {
            //Arrange

            IController controller = new FakeATMController();
            ISeparationDetector _uut = controller.separationDetector;
            List<IVehicle> vehicles = new List<IVehicle>();

            //Adding two colliding airplanes
            Airplane vehicleA = new Airplane();
            vehicleA.Altitude = 100;
            vehicleA.Xcoordinate = 100;
            vehicleA.Ycoordinate = 100;

            Airplane vehicleB = new Airplane();
            vehicleA.Altitude = 600;
            vehicleA.Xcoordinate = 99;
            vehicleA.Ycoordinate = 99;

            vehicles.Add(vehicleA);
            vehicles.Add(vehicleB);

            controller.vehicles = vehicles;

            //Act
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.Null(controller.separations);

        }

    }
}
