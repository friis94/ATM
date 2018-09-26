using System;
using System.Collections.Generic;
using System.Linq;
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
            bool result = false;
            Assert.IsFalse(result, "Dummy test");
        }
        
    }
}
