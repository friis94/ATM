using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class TrackDetectorUnitTest
    {
        private TrackDetector uut;
        private List<IVehicle> newVehicles;
        private List<IVehicle> oldVehicles;
        private int eventEnterCount;
        private int eventEnterRemoveCount;
        private int eventExitCount;
        private int eventExitRemoveCount;

        [SetUp]
        public void Setup()
        {
            Thread.Sleep(5100);

            uut = new TrackDetector();
            newVehicles = new List<IVehicle>();
            oldVehicles = new List<IVehicle>();

            eventEnterCount = 0;
            eventEnterRemoveCount = 0;

            uut.EnterEvent += (sender, e) => eventEnterCount += 1;
            uut.EnterEventRemove += (sender, e) => eventEnterRemoveCount += 1;

            eventExitCount = 0;
            eventExitRemoveCount = 0;

            uut.ExitEvent += (sender, e) => eventExitCount += 1;
            uut.ExitEventRemove += (sender, e) => eventExitRemoveCount += 1;
        }

        [Test]
        public void DetectOneTrackEnterEvent_AddNewVehicleToList_EventCountIsOne()
        {
            IVehicle airplaneA = new Airplane();
            airplaneA.Tag = "ATV222";
            airplaneA.YCoordinate = 2000;
            airplaneA.XCoordinate = 1500;
            airplaneA.Timestamp = DateTime.Parse("2000/12/24 18:01:10");

            newVehicles.Add(airplaneA);

            uut.Update(newVehicles, oldVehicles);

            Assert.That(eventEnterCount, Is.EqualTo(1));
        }


        [Test]
        public void DetectNoTrackEnterEvent_SameVehiclesInList_EventCountIsZero()
        {
            IVehicle airplaneA = new Airplane();
            airplaneA.Tag = "ATV222";
            airplaneA.YCoordinate = 2000;
            airplaneA.XCoordinate = 1500;
            airplaneA.Timestamp = DateTime.Parse("2000/12/24 18:01:10");

            newVehicles.Add(airplaneA);

            IVehicle airplaneB = new Airplane();
            airplaneB.Tag = "ATV222";
            airplaneB.YCoordinate = 5000;
            airplaneB.XCoordinate = 500;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            oldVehicles.Add(airplaneB);

            uut.Update(newVehicles, oldVehicles);

            Assert.That(eventEnterCount, Is.EqualTo(0));
        }

        [Test]
        public void DetectOneTrackExitEvent_AddOldVehiclestoList_EventCountIsOne()
        {
            IVehicle airplaneB = new Airplane();
            airplaneB.Tag = "ATV222";
            airplaneB.YCoordinate = 5000;
            airplaneB.XCoordinate = 500;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            oldVehicles.Add(airplaneB);

            uut.Update(newVehicles, oldVehicles);

            Assert.That(eventExitCount, Is.EqualTo(1));
        }

        [Test]
        public void DetectNoTrackExitEvent_SameVehiclesInList_EventCountIsZero()
        {
            IVehicle airplaneA = new Airplane();
            airplaneA.Tag = "ATV222";
            airplaneA.YCoordinate = 2000;
            airplaneA.XCoordinate = 1500;
            airplaneA.Timestamp = DateTime.Parse("2000/12/24 18:01:10");

            newVehicles.Add(airplaneA);

            IVehicle airplaneB = new Airplane();
            airplaneB.Tag = "ATV222";
            airplaneB.YCoordinate = 5000;
            airplaneB.XCoordinate = 500;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            oldVehicles.Add(airplaneB);

            uut.Update(newVehicles, oldVehicles);

            Assert.That(eventExitCount, Is.EqualTo(0));
        }


        [Test]
        public void DetectOneTrackEnterRemoveEvent_AddToNewVehicleList_WaitLongEnough()
        {
            IVehicle airplaneB = new Airplane();
            airplaneB.Tag = "ATV222";
            airplaneB.YCoordinate = 5000;
            airplaneB.XCoordinate = 500;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            newVehicles.Add(airplaneB);

            uut.Update(newVehicles, oldVehicles);

            Thread.Sleep(5100);

            Assert.That(eventEnterRemoveCount, Is.EqualTo(1));
        }

        [Test]
        public void DetectNoTrackEnterRemoveEvent_AddToNewVehicleList_WaitNotLongEnough()
        {
            IVehicle airplaneB = new Airplane();
            airplaneB.Tag = "ATV222";
            airplaneB.YCoordinate = 5000;
            airplaneB.XCoordinate = 500;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            newVehicles.Add(airplaneB);

            uut.Update(newVehicles, oldVehicles);

            Thread.Sleep(4900);

            Assert.That(eventEnterRemoveCount, Is.EqualTo(0));
        }

        [Test]
        public void DetectOneTrackExitRemoveEvent_AddToOldVehicleList_WaitLongEnough()
        {
            IVehicle airplaneB = new Airplane();
            airplaneB.Tag = "ATV222";
            airplaneB.YCoordinate = 5000;
            airplaneB.XCoordinate = 500;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            oldVehicles.Add(airplaneB);

            uut.Update(newVehicles, oldVehicles);

            Thread.Sleep(5100);

            Assert.That(eventExitRemoveCount, Is.EqualTo(1));
        }

        [Test]
        public void DetectNoTrackExitRemoveEvent_AddToOldVehicleList_WaitNotLongEnough()
        {
            IVehicle airplaneB = new Airplane();
            airplaneB.Tag = "ATV222";
            airplaneB.YCoordinate = 5000;
            airplaneB.XCoordinate = 500;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            oldVehicles.Add(airplaneB);

            uut.Update(newVehicles, oldVehicles);

            Thread.Sleep(4900);

            Assert.That(eventExitRemoveCount, Is.EqualTo(0));
        }


    }
}
