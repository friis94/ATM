using System;
using System.Collections.Generic;
using ATM.Unit.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace ATM.Integration.Test
{
    [TestFixture]
    public class IntegrationStep5
    {

        [TestMethod]
        public void IntegrationTestNonColidingAirPlanesLoggedToConsole()
        {
            /*
             * ARRANGE
             */

            IAirspaceFilter airspaceFilter = new AirspaceFilter();
            ICourseCalculator courseCalculator = new CourseCalculator();
            ITrackDetector trackDetector = new TrackDetector();
            ISeparationDetector separationDetector = new SeparationDetector();

            // Fake transponder receiver to generate data
            FakeTransponderReceiver fakeTransponderReceiver = new FakeTransponderReceiver();

            // Stub to assert on
            IConsoleLogger consoleLogger = Substitute.For<IConsoleLogger>();

            // Needed to create ATMController

            IFileLogger fileLogger = Substitute.For<IFileLogger>();

            IController controller = new ATMController(fakeTransponderReceiver, fileLogger, consoleLogger,
                separationDetector, trackDetector, airspaceFilter, courseCalculator);

            /*
             * ACT
             */
            fakeTransponderReceiver.transpondNotCollidingAirplanes();

            /*
             * Assert
             */
            consoleLogger.Received().SetVehicles(Arg.Any<List<IVehicle>>());

        }
    }
}
