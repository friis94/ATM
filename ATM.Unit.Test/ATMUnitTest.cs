using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class ATMUnitTest
    {
        [TestCase()]
        public void DummyTest()
        {
            bool result = true;
            Assert.IsFalse(result, "Dummy test");
        }
    }
}
