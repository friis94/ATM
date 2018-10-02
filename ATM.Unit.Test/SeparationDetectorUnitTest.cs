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
            vehicleB.Altitude = 99;
            vehicleB.Xcoordinate = 99;
            vehicleB.Ycoordinate = 99;

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
            vehicleB.Altitude = 600;
            vehicleB.Xcoordinate = 99;
            vehicleB.Ycoordinate = 99;

            vehicles.Add(vehicleA);
            vehicles.Add(vehicleB);

            controller.vehicles = vehicles;

            //Act
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.Null(controller.separations);

        }

        [Test]
        public void DetectTwoOfThreeOnCollision_AddTwoVehiclesOnCollisionAndOneNot_SeperationsCountInControllerIsTwo()
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
            vehicleB.Altitude = 100;
            vehicleB.Xcoordinate = 99;
            vehicleB.Ycoordinate = 99;

            Airplane vehicleC = new Airplane();
            vehicleC.Altitude = 100;
            vehicleC.Xcoordinate = 10000;
            vehicleC.Ycoordinate = 10000;

            vehicles.Add(vehicleA);
            vehicles.Add(vehicleB);
            vehicles.Add(vehicleC);
            

            controller.vehicles = vehicles;

            //Act
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.That(controller.separations.Count.Equals(2));
        }

        [Test]
        public void NoAirplanesNoDetection_AddEmptyList_SeperationsInControllerIsNull()
        {
            //Arrange

            IController controller = new FakeATMController();
            ISeparationDetector _uut = controller.separationDetector;
            List<IVehicle> vehicles = new List<IVehicle>();

            controller.vehicles = vehicles;

            //Act
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.Null(controller.separations);
        }


        [Test]
        public void SeperationsStaysOnList_AddSeperationTimesTwo_FirstSeperationIsStillInList()
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
            vehicleB.Altitude = 100;
            vehicleB.Xcoordinate = 99;
            vehicleB.Ycoordinate = 99;

            Airplane vehicleC = new Airplane();
            vehicleC.Altitude = 99;
            vehicleC.Xcoordinate = 99;
            vehicleC.Ycoordinate = 99;


            vehicles.Add(vehicleA);
            vehicles.Add(vehicleB);


            controller.vehicles = vehicles;

            //Act
            _uut.CalculateSeparations(vehicles);
            ISeparation seperation = controller.separations[0];

            vehicles.Add(vehicleC);
            controller.vehicles = vehicles;
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.That(controller.separations[0].VehicleA.Equals(seperation.VehicleA) && controller.separations[0].VehicleB.Equals(seperation.VehicleB));
        }


        [Test]
        public void SeperationsGoneFromList_AddSeperationTimesTwoThenRemoveFirst_FirstSeperationIsGoneFromList()
        {
            //Arrange

            IController controller = new FakeATMController();
            ISeparationDetector _uut = controller.separationDetector;
            List<IVehicle> vehicles = new List<IVehicle>();

            //Adding three colliding airplanes
            Airplane vehicleA = new Airplane();
            vehicleA.Altitude = 100;
            vehicleA.Xcoordinate = 100;
            vehicleA.Ycoordinate = 100;

            Airplane vehicleB = new Airplane();
            vehicleB.Altitude = 100;
            vehicleB.Xcoordinate = 99;
            vehicleB.Ycoordinate = 99;

            Airplane vehicleC = new Airplane();
            vehicleC.Altitude = 99;
            vehicleC.Xcoordinate = 99;
            vehicleC.Ycoordinate = 99;


            vehicles.Add(vehicleA);
            vehicles.Add(vehicleB);


            controller.vehicles = vehicles;

            //Act
            _uut.CalculateSeparations(vehicles);
            ISeparation seperation = controller.separations[0];


            vehicles.RemoveAt(0);
            vehicles.Add(vehicleC);
            _uut.CalculateSeparations(vehicles);
            
            //Assert
            Assert.AreNotEqual(controller.separations[0],seperation);
        }



        [Test]
        public void AbleToHandleNoVehicles_AddNoVehicles_NoExceptionIsThrown()
        {
            //Arrange

            IController controller = new FakeATMController();
            ISeparationDetector _uut = controller.separationDetector;
            List<IVehicle> vehicles = new List<IVehicle>();
            
            controller.vehicles = vehicles;

            //No Act



            //Assert
            Assert.DoesNotThrow(() => { _uut.CalculateSeparations(vehicles); });
        }

        [Test]
        public void AbleToHandleOneVehicle_AddOneVehicles_NoExceptionIsThrown()
        {
            //Arrange

            IController controller = new FakeATMController();
            ISeparationDetector _uut = controller.separationDetector;
            List<IVehicle> vehicles = new List<IVehicle>();

            controller.vehicles = vehicles;
            
            //No Act
            //Adding two colliding airplanes
            Airplane vehicleA = new Airplane();
            vehicleA.Altitude = 100;
            vehicleA.Xcoordinate = 100;
            vehicleA.Ycoordinate = 100;

            vehicles.Add(vehicleA);
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.DoesNotThrow(() => { _uut.CalculateSeparations(vehicles); });
        }



    }
}
