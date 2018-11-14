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
    public class TimerUnitTest
    {
        private Timer uut;
        private List<IVehicle> vehicles = new List<IVehicle>();

        [SetUp]
        public void Setup()
        {
            uut = new Timer(1000, vehicles);
        }

        [Test]
        public void Start_TimerExpires_LongEnough()
        {
            ManualResetEvent pause = new ManualResetEvent(false);

            uut.Expired += (sender, args) => pause.Set();
            uut.Start();

            // wait for expiration, but not much longer, should come
            Assert.That(pause.WaitOne(1100));
        }

        [Test]
        public void Start_TimerExpires_WaitNotLongEnough()
        {
            ManualResetEvent pause = new ManualResetEvent(false);

            uut.Expired += (sender, args) => pause.Set();
            uut.Start();


            Assert.That(!pause.WaitOne(900));
        }
    }
}
