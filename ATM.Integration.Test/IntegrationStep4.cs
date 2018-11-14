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
    public class IntegrationStep4
    {

        [Test]
        public void IntegrationTestSeparationDetectorReceivedVehicles()
        {
            /*
             * ARRANGE
             */

            IAirspaceFilter airspaceFilter = new AirspaceFilter();
            ICourseCalculator courseCalculator = new CourseCalculator();
            ITrackDetector trackDetector = new TrackDetector();

            // Fake transponder receiver to generate data
            FakeTransponderReceiver fakeTransponderReceiver = new FakeTransponderReceiver();

            // Stub to assert on
            ISeparationDetector separationDetector = Substitute.For<ISeparationDetector>();
          
            // Needed to create ATMController
            IConsoleLogger consoleLogger = Substitute.For<IConsoleLogger>();
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
            separationDetector.Received().CalculateSeparations(Arg.Any<List<IVehicle>>());

        }
    }
}
