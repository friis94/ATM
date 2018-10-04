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

        private ISeparationDetector _uut;
        private List<IVehicle> _vehicles;
        private int eventRaisedCount;
        [SetUp]
        public void Init()
        {
            
            eventRaisedCount = 0;
            _uut = new SeparationDetector();
            _uut.SeparationEvent += (o, e) => eventRaisedCount += 1;
            _vehicles = new List<IVehicle>();
        }

        [Test]
        public void DetectOneSeparationEvent_AddTwoVehiclesOnCollision_SeparationsEventCountIsOne()
        {
    
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

            _vehicles.Add(vehicleA);
            _vehicles.Add(vehicleB);

            //Act
            _uut.CalculateSeparations(_vehicles);

            //Assert
            Assert.That(eventRaisedCount, Is.EqualTo(1));
        }

        [Test]
        public void DontDetectSeperationEvent_AddTwoVehiclesNotOnCollision_SeperationsEventNotRaised()
        {

            //Adding two colliding airplanes
            Airplane vehicleA = new Airplane();
            vehicleA.Altitude = 100;
            vehicleA.Xcoordinate = 100;
            vehicleA.Ycoordinate = 100;

            Airplane vehicleB = new Airplane();
            vehicleB.Altitude = 600;
            vehicleB.Xcoordinate = 99;
            vehicleB.Ycoordinate = 99;

            _vehicles.Add(vehicleA);
            _vehicles.Add(vehicleB);

            //Act
            _uut.CalculateSeparations(_vehicles);

            //Assert
            Assert.That(eventRaisedCount, Is.EqualTo(0));
        }

        [Test]
        public void HandleEmptyVehicleList_AddNoVehicles_NoExceptionIsThrown()
        {
            //Assert
            Assert.DoesNotThrow(() => { _uut.CalculateSeparations(_vehicles); });
        }

        [Test]
        public void AbleToHandleOneVehicle_AddOneVehicles_NoExceptionIsThrown()
        {

            //Act - Add one vehicle
            Airplane vehicleA = new Airplane();
            vehicleA.Altitude = 100;
            vehicleA.Xcoordinate = 100;
            vehicleA.Ycoordinate = 100;

            _vehicles.Add(vehicleA);
            
            //Assert
            Assert.DoesNotThrow(() => { _uut.CalculateSeparations(_vehicles); });
        }

        [Test]
        public void AltitudeBoundaryExceeded_TwoVehiclesWithBoundaryEdge_NoSeperationIsDetected()
        {
            // Arrange
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

            _vehicles.Add(vehicleA);
            _vehicles.Add(vehicleB);

            //Act
            _uut.CalculateSeparations(_vehicles);

            //Assert
            Assert.That(eventRaisedCount, Is.EqualTo(0));
        }


        [Test]
        public void AltitudeBoundaryWithin_TwoVehiclesWithBoundaryEdge_OneSeperationIsDetected()
        {
            //Arrange
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

            _vehicles.Add(vehicleA);
            _vehicles.Add(vehicleB);

            //Act
            _uut.CalculateSeparations(_vehicles);

            //Assert
            Assert.That(eventRaisedCount, Is.EqualTo(1));
        }

        [Test]
        public void LocationBoundaryWithin_TwoVehiclesWithBoundaryEdge_OneSeperationIsDetected()
        {

            //Arrange
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
            _vehicles.Add(vehicleA);
            _vehicles.Add(vehicleB);

            //Act
            _uut.CalculateSeparations(_vehicles);

            //Assert
            Assert.That(eventRaisedCount, Is.EqualTo(1));
        }


        [Test]
        public void LocationBoundaryExceeded_TwoVehiclesWithBoundaryEdge_NoSeperationIsDetected()
        {
            //Arrange
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

            _vehicles.Add(vehicleA);
            _vehicles.Add(vehicleB);

            //Act
            _uut.CalculateSeparations(_vehicles);

            //Assert
            Assert.That(eventRaisedCount, Is.EqualTo(0));
        }


    }

}


