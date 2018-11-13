using System;
using System.Collections.Generic;
using ATM.Unit.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TransponderReceiver;

namespace ATM.Integration.Test
{
    [TestClass]
    public class IntegrationStep1
    {

        [TestMethod]
        public void IntegrationTestDecoder()
        {
            /*
             * ARRANGE
             */

            IDecoder decoder = new Decoder();

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

            IController controller = new ATMController(fakeTransponderReceiver, fileLogger, consoleLogger,
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
