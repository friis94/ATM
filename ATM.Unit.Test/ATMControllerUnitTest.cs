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
        public void RegisterCollidingAirplaes_TranspondTwoCollidingAirplanes_SeperationEventExecuted()
        {
            /*FakeTransponderReceiver _transponderReceiver = new FakeTransponderReceiver();
            IFileWriter fileWriter = new FileWriter();

            ATMController _uut = new ATMController(_transponderReceiver);
            _transponderReceiver.transpondCollidingAirplanes();


            _uut.Received().Update(new object(), new SeparationChangedEventArgs());*/

        }

    }
}
