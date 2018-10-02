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
            vehicleA.Tag = "tag1";

            Airplane vehicleB = new Airplane();
            vehicleB.Altitude = 99;
            vehicleB.Xcoordinate = 99;
            vehicleB.Ycoordinate = 99;
            vehicleB.Tag = "tag2";

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
        public void DetectOneSeperationEvent_AddTwoVehiclesOnCollision_SeperationsCountInControllerIsTwo()
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
            vehicleA.Tag = "tag1";

            Airplane vehicleB = new Airplane();
            vehicleB.Altitude = 100;
            vehicleB.Xcoordinate = 99;
            vehicleB.Ycoordinate = 99;
            vehicleB.Tag = "tag2";

            //Testing with an airplane thats exactly on the edge of altitude boundary for seperation
            Airplane vehicleC = new Airplane();
            vehicleC.Altitude = 400;
            vehicleC.Xcoordinate = 99;
            vehicleC.Ycoordinate = 99;
            vehicleC.Tag = "tag3";

            vehicles.Add(vehicleA);
            vehicles.Add(vehicleB);
            vehicles.Add(vehicleC);
            

            controller.vehicles = vehicles;

            //Act
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.That(controller.separations.Count.Equals(1));
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
            vehicleA.Tag = "tag1";

            Airplane vehicleB = new Airplane();
            vehicleB.Altitude = 100;
            vehicleB.Xcoordinate = 99;
            vehicleB.Ycoordinate = 99;
            vehicleB.Tag = "tag2";

            Airplane vehicleC = new Airplane();
            vehicleC.Altitude = 99;
            vehicleC.Xcoordinate = 99;
            vehicleC.Ycoordinate = 99;
            vehicleC.Tag = "tag3";


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
            vehicleA.Tag = "tag1";

            Airplane vehicleB = new Airplane();
            vehicleB.Altitude = 100;
            vehicleB.Xcoordinate = 99;
            vehicleB.Ycoordinate = 99;
            vehicleB.Tag = "tag2";

            Airplane vehicleC = new Airplane();
            vehicleC.Altitude = 99;
            vehicleC.Xcoordinate = 99;
            vehicleC.Ycoordinate = 99;
            vehicleC.Tag = "tag3";


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
            Airplane vehicleA = new Airplane();
            vehicleA.Altitude = 100;
            vehicleA.Xcoordinate = 100;
            vehicleA.Ycoordinate = 100;

            vehicles.Add(vehicleA);
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.DoesNotThrow(() => { _uut.CalculateSeparations(vehicles); });
        }

        [Test]
        public void AltitudeBoundaryExceeded_TwoVehiclesWithBoundaryEdge_NoSeperationIsDetected()
        {
            //Arrange

            IController controller = new FakeATMController();
            ISeparationDetector _uut = controller.separationDetector;
            List<IVehicle> vehicles = new List<IVehicle>();

            controller.vehicles = vehicles;
            
            //Act
            //Adding two not colliding airplanes
            Airplane vehicleA = new Airplane();
            vehicleA.Altitude = 100;
            vehicleA.Xcoordinate = 100;
            vehicleA.Ycoordinate = 100;
            vehicleA.Tag = "tag1";

            Airplane vehicleB = new Airplane();
            vehicleB.Altitude = 400;
            vehicleB.Xcoordinate = 100;
            vehicleB.Ycoordinate = 100;
            vehicleB.Tag = "tag2";

            vehicles.Add(vehicleA);
            vehicles.Add(vehicleB);
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.Null(controller.separations);
        }


        [Test]
        public void AltitudeBoundaryWithin_TwoVehiclesWithBoundaryEdge_OneSeperationIsDetected()
        {
            //Arrange

            IController controller = new FakeATMController();
            ISeparationDetector _uut = controller.separationDetector;
            List<IVehicle> vehicles = new List<IVehicle>();

            controller.vehicles = vehicles;

            //Act
            //Adding two colliding airplanes
            Airplane vehicleA = new Airplane();
            vehicleA.Altitude = 100;
            vehicleA.Xcoordinate = 100;
            vehicleA.Ycoordinate = 100;
            vehicleA.Tag = "tag1";

            Airplane vehicleB = new Airplane();
            vehicleB.Altitude = 399;
            vehicleB.Xcoordinate = 100;
            vehicleB.Ycoordinate = 100;
            vehicleB.Tag = "tag2";

            vehicles.Add(vehicleA);
            vehicles.Add(vehicleB);
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.That(controller.separations.Count.Equals(1));
        }

        [Test]
        public void LocationBoundaryWithin_TwoVehiclesWithBoundaryEdge_OneSeperationIsDetected()
        {
            //Arrange

            IController controller = new FakeATMController();
            ISeparationDetector _uut = controller.separationDetector;
            List<IVehicle> vehicles = new List<IVehicle>();

            controller.vehicles = vehicles;

            //Act
            //Adding two colliding airplanes
            Airplane vehicleA = new Airplane();
            vehicleA.Altitude = 100;
            vehicleA.Xcoordinate = 100;
            vehicleA.Ycoordinate = 5099;
            vehicleA.Tag = "tag1";

            Airplane vehicleB = new Airplane();
            vehicleB.Altitude = 100;
            vehicleB.Xcoordinate = 100;
            vehicleB.Ycoordinate = 100;
            vehicleB.Tag = "tag2";

            vehicles.Add(vehicleA);
            vehicles.Add(vehicleB);
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.That(controller.separations.Count.Equals(1));
        }


        [Test]
        public void LocationBoundaryExceeded_TwoVehiclesWithBoundaryEdge_NoSeperationIsDetected()
        {
            //Arrange

            IController controller = new FakeATMController();
            ISeparationDetector _uut = controller.separationDetector;
            List<IVehicle> vehicles = new List<IVehicle>();

            controller.vehicles = vehicles;

            //Act
            //Adding two not colliding airplanes
            Airplane vehicleA = new Airplane();
            vehicleA.Altitude = 100;
            vehicleA.Xcoordinate = 100;
            vehicleA.Ycoordinate = 100;
            vehicleA.Tag = "tag1";

            Airplane vehicleB = new Airplane();
            vehicleB.Altitude = 100;
            vehicleB.Xcoordinate = 100;
            vehicleB.Ycoordinate = 5100;
            vehicleB.Tag = "tag2";

            vehicles.Add(vehicleA);
            vehicles.Add(vehicleB);
            _uut.CalculateSeparations(vehicles);

            //Assert
            Assert.Null(controller.separations);
        }


    }

}




