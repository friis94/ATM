using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace ATM.Unit.Test
{
    [TestFixture]
    class ATMControllerUnitTest
    {

        [Test]
        public void ATMControllerTest_TranspondTwoCollidingsAirplanes_FileLogAirplanes()
        {
            FakeTransponderReceiver _transponderReceiver = new FakeTransponderReceiver();

            IFileLogger fileLogger = Substitute.For<IFileLogger>();

            IConsoleLogger consoleLogger = Substitute.For<IConsoleLogger>();
             
            
            ATMController _uut = new ATMController(_transponderReceiver, fileLogger, consoleLogger);
            _transponderReceiver.transpondCollidingAirplanes();

            fileLogger.Received().Log(Arg.Any<ISeparation>());
        }

        [Test]
        public void ATMControllerTest_TranspondTwoNonCollidingsAirplanes_AirplanesNotFileLogged()
        {
            FakeTransponderReceiver _transponderReceiver = new FakeTransponderReceiver();

            IFileLogger fileLogger = Substitute.For<IFileLogger>();

            IConsoleLogger consoleLogger = Substitute.For<IConsoleLogger>();


            ATMController _uut = new ATMController(_transponderReceiver, fileLogger, consoleLogger);
            _transponderReceiver.transpondNotCollidingAirplanes();

            fileLogger.DidNotReceive().Log(Arg.Any<ISeparation>());
        }

        [Test]
        public void ATMControllerTest_TranspondTwoNonCollidingsAirplanes_AirplanesConsoleLogged()
        {
            FakeTransponderReceiver _transponderReceiver = new FakeTransponderReceiver();

            IFileLogger fileLogger = Substitute.For<IFileLogger>();

            IConsoleLogger consoleLogger = Substitute.For<IConsoleLogger>();


            ATMController _uut = new ATMController(_transponderReceiver, fileLogger, consoleLogger);
            _transponderReceiver.transpondNotCollidingAirplanes();

            consoleLogger.Received().SetVehicles(Arg.Any<List<IVehicle>>());
        }

        [Test]
        public void ATMControllerTest_TranspondNoAirplanes_AirplanesNotConsoleLogged()
        {
            FakeTransponderReceiver _transponderReceiver = new FakeTransponderReceiver();

            IFileLogger fileLogger = Substitute.For<IFileLogger>();

            IConsoleLogger consoleLogger = Substitute.For<IConsoleLogger>();


            ATMController _uut = new ATMController(_transponderReceiver, fileLogger, consoleLogger);
            _transponderReceiver.transpondNoAirplanes();

            consoleLogger.DidNotReceive().SetVehicles(Arg.Any<List<IVehicle>>());
        }

    }
}
