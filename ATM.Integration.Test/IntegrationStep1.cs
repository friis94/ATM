using System;
using System.Collections.Generic;
using ATM.Unit.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TransponderReceiver;
using NUnit.Framework;

namespace ATM.Integration.Test
{
    [TestFixture]
    public class IntegrationStep1
    {

        [Test]
        public void IntegrationTestDecoder()
        {
            /*
             * ARRANGE
             */

            // Fake transponder receiver to generate data
            FakeTransponderReceiver fakeTransponderReceiver = new FakeTransponderReceiver();

            // Stub to assert on
            IAirspaceFilter fakeAirspaceFilter = Substitute.For<IAirspaceFilter>();
            fakeAirspaceFilter.FilterVehicles(Arg.Any<List<IVehicle>>()).Returns(new List<IVehicle>());

            // Needed to create ATMController
            ISeparationDetector separationDetector = new SeparationDetector();
            ITrackDetector trackDetector = Substitute.For<ITrackDetector>();
            IConsoleLogger consoleLogger = Substitute.For<IConsoleLogger>();
            IFileLogger fileLogger = Substitute.For<IFileLogger>();
            ICourseCalculator courseCalculator = new CourseCalculator();

            IController controller = new AtmController(fakeTransponderReceiver, fileLogger, consoleLogger,
                separationDetector, trackDetector, fakeAirspaceFilter, courseCalculator);

            /*
             * ACT
             */
            fakeTransponderReceiver.transpondNotCollidingAirplanes();

            /*
             * Assert
             */
            fakeAirspaceFilter.Received().FilterVehicles(Arg.Any<List<IVehicle>>());

        }
    }
}
