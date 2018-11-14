using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class TrackDetectorUnitTest
    {
        private TrackDetector uut;

        [SetUp]
        public void Setup()
        {
            uut = new TrackDetector();
        }

    }
}
