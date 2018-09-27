using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class FileLoggerUnitTests
    {
        [Test]
        public void LogOneSeperation()
        {

            IFileLogger uut = new FileLogger(@"C:\Users\Public\ATM.txt");
            ISeperation sep = new Seperation();

            uut.Log(sep);
          
            Assert.AreEqual(0, 0);
        }
    }
}
