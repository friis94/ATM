using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class CourseCalculatorUnitTest
    {

        [Test]
        public void CourseCalulatorTest_ReturnNewVehiclesWithNoChangeWhenOldListIsEmpty()
        {
            CourseCalculator uut = new CourseCalculator();

            List<IVehicle> newVehicles = new List<IVehicle>();
            List<IVehicle> oldVehicles = new List<IVehicle>();

            IVehicle airplaneA = new Airplane();
            airplaneA.Tag = "ATV222";
            airplaneA.Xcoordinate = 1000;
            airplaneA.Timestamp = DateTime.Parse("2000/12/24 18:01:10");

            newVehicles.Add(airplaneA);

            Assert.That(uut.CalculateCourse(newVehicles, oldVehicles).Equals(newVehicles));
        }

        [Test]
        public void CourseCalulatorTest_ReturnEmptyVehiclesList()
        {
            CourseCalculator uut = new CourseCalculator();

            List<IVehicle> newVehicles = new List<IVehicle>();
            List<IVehicle> oldVehicles = new List<IVehicle>();

           Assert.That(uut.CalculateCourse(newVehicles, oldVehicles).Equals(newVehicles));
        }

        [Test]
         public void CourseCalculatorTest_CorrectSpeedWhenXcoordChange()
        {
            CourseCalculator uut = new CourseCalculator();

            List<IVehicle> newVehicles = new List<IVehicle>();
            List<IVehicle> oldVehicles = new List<IVehicle>();


            IVehicle airplaneA = new Airplane();
            airplaneA.Tag = "ATV222";
            airplaneA.Xcoordinate = 1000;
            airplaneA.Timestamp = DateTime.Parse("2000/12/24 18:01:10");

            newVehicles.Add(airplaneA);
            
            IVehicle airplaneB = new Airplane();
            airplaneB.Tag = "ATV222";
            airplaneB.Xcoordinate = 5000;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            oldVehicles.Add(airplaneB);

            newVehicles = uut.CalculateCourse(newVehicles, oldVehicles);

            Assert.AreEqual(newVehicles.First().velocity, 57);

        }

        [Test]
        public void CourseCalculatorTest_CorrectSpeedWhenYcoordChange()
        {
            CourseCalculator uut = new CourseCalculator();

            List<IVehicle> newVehicles = new List<IVehicle>();
            List<IVehicle> oldVehicles = new List<IVehicle>();


            IVehicle airplaneA = new Airplane();
            airplaneA.Tag = "ATV222";
            airplaneA.Ycoordinate = 2000;
            airplaneA.Timestamp = DateTime.Parse("2000/12/24 18:01:10");

            newVehicles.Add(airplaneA);

            IVehicle airplaneB = new Airplane();
            airplaneB.Tag = "ATV222";
            airplaneB.Ycoordinate = 5000;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            oldVehicles.Add(airplaneB);

            newVehicles = uut.CalculateCourse(newVehicles, oldVehicles);

            Assert.AreEqual(newVehicles.First().velocity, 42);
        }

        [Test]
        public void CourseCalculatorTest_CorrectSpeedWhenBothCoordinatesChange()
        {
            CourseCalculator uut = new CourseCalculator();

            List<IVehicle> newVehicles = new List<IVehicle>();
            List<IVehicle> oldVehicles = new List<IVehicle>();


            IVehicle airplaneA = new Airplane();
            airplaneA.Tag = "ATV222";
            airplaneA.Ycoordinate = 2000;
            airplaneA.Xcoordinate = 1500;
            airplaneA.Timestamp = DateTime.Parse("2000/12/24 18:01:10");

            newVehicles.Add(airplaneA);

            IVehicle airplaneB = new Airplane();
            airplaneB.Tag = "ATV222";
            airplaneB.Ycoordinate = 5000;
            airplaneB.Xcoordinate = 500;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            oldVehicles.Add(airplaneB);

            newVehicles = uut.CalculateCourse(newVehicles, oldVehicles);

            Assert.AreEqual(newVehicles.First().velocity, 45);
        }

        [Test]
        public void CourseCalculatorTest_CorrectCourseWhenBothCoordinatesChange()
        {
            CourseCalculator uut = new CourseCalculator();

            List<IVehicle> newVehicles = new List<IVehicle>();
            List<IVehicle> oldVehicles = new List<IVehicle>();


            IVehicle airplaneA = new Airplane();
            airplaneA.Tag = "ATV222";
            airplaneA.Ycoordinate = 2000;
            airplaneA.Xcoordinate = 1500;
            airplaneA.Timestamp = DateTime.Parse("2000/12/24 18:01:10");

            newVehicles.Add(airplaneA);

            IVehicle airplaneB = new Airplane();
            airplaneB.Tag = "ATV222";
            airplaneB.Ycoordinate = 5000;
            airplaneB.Xcoordinate = 500;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            oldVehicles.Add(airplaneB);

            newVehicles = uut.CalculateCourse(newVehicles, oldVehicles);

            Assert.AreEqual(newVehicles.First().course, 289);
        }

        [Test]
        public void CourseCalculatorTest_UpdateVelocityWithMoreThanOneAirplaneInOldList()
        {
            CourseCalculator uut = new CourseCalculator();

            List<IVehicle> newVehicles = new List<IVehicle>();
            List<IVehicle> oldVehicles = new List<IVehicle>();


            IVehicle airplaneA = new Airplane();
            airplaneA.Tag = "ATV222";
            airplaneA.Ycoordinate = 2000;
            airplaneA.Xcoordinate = 1500;
            airplaneA.Timestamp = DateTime.Parse("2000/12/24 18:01:10");

            newVehicles.Add(airplaneA);

            IVehicle airplaneB = new Airplane();
            airplaneB.Tag = "ATV222";
            airplaneB.Ycoordinate = 5000;
            airplaneB.Xcoordinate = 500;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            IVehicle airplaneC = new Airplane();
            airplaneB.Tag = "AAS222";
            airplaneB.Ycoordinate = 5006;
            airplaneB.Xcoordinate = 500;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            IVehicle airplaneD = new Airplane();
            airplaneB.Tag = "ATX222";
            airplaneB.Ycoordinate = 5000;
            airplaneB.Xcoordinate = 9000;
            airplaneB.Timestamp = DateTime.Parse("2000/12/24 18:00:0");

            oldVehicles.Add(airplaneD);
            oldVehicles.Add(airplaneC);
            oldVehicles.Add(airplaneB);

            newVehicles = uut.CalculateCourse(newVehicles, oldVehicles);

            Assert.IsFalse(newVehicles.First().Equals(0));
        }
    }
}
