using System;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class FileLoggerUnitTests
    {
        [Test]
        public void SeparationFileLoggerTest()
        {
            // Mock of FileWriter
            IFileWriter fileWriter = Substitute.For<IFileWriter>();

            // Logger
            IFileLogger uut = new FileLogger(fileWriter);

            // Separation event between to airplane A and B
            IVehicle airplaneA = new Airplane();
            IVehicle airplaneB = new Airplane();
            airplaneA.Tag = "Airplane A";
            airplaneB.Tag = "Airplane B";
            DateTime dt = DateTime.Parse("2000/12/24 18:00:10");

            ISeparation sep = new Separation(airplaneA, airplaneB, dt);

            // Call log on UUT
            uut.Log(sep);

            fileWriter.Received().WriteLine("[Separation Event] between Airplane A and Airplane B @ 2000-12-24 18:00:10.000");

        }
    }
}
