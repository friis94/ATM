using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class DecoderUnitTest
    {
        [TestCase()]
        public void DecoderTest_TagIsCorrect()
        {

            ATM.Decoder uut = new ATM.Decoder();

            List<string> de = new List<string>();

            de.Add("ATR423;39045;12932;14000;20151006213456789");
            de.Add("ATT423;39045;12932;14000;20151006213456789");

            List<IVehicle> ve = uut.Decode(de);

            var vehicle = ve.First();

            Assert.AreEqual(vehicle.Tag, "ATR423");
        }

        [TestCase()]
        public void DecoderTest_SecondTagIsCorrect()
        { 

            ATM.Decoder uut = new ATM.Decoder();

            List<string> de = new List<string>();

            de.Add("ATR423;39045;12932;14000;20151006213456789");
            de.Add("ATT423;39045;12932;14000;20151006213456789");

            List<IVehicle> ve = uut.Decode(de);

            var vehicle = ve.Last();

            Assert.AreEqual(vehicle.Tag, "ATT423");
        }

        [TestCase()]
        public void DecoderTest_XcoordinateIsCorrect()
        {

            ATM.Decoder uut = new ATM.Decoder();

            List<string> de = new List<string>();

            de.Add("ATR423;39045;12932;14000;20151006213456789");

            List<IVehicle> ve = uut.Decode(de);

            var vehicle = ve.First();

            Assert.AreEqual(vehicle.Xcoordinate, 39045);
        }

        [Test]
        public void DecoderTest_XcoordinateException()
        {
            ATM.Decoder uut = new ATM.Decoder();

            List<string> de = new List<string>();

            de.Add("ATR423;390f5;12932;14000;20151006213456789");

            Assert.ThrowsException<FormatException>(() => uut.Decode(de));
        }

        [TestCase()]
        public void DecoderTest_YcoordinateIsCorrect()
        {

            ATM.Decoder uut = new ATM.Decoder();

            List<string> de = new List<string>();

            de.Add("ATR423;39045;12932;14000;20151006213456789");

            List<IVehicle> ve = uut.Decode(de);

            var vehicle = ve.First();

            Assert.AreEqual(vehicle.Ycoordinate, 12932);
        }

        [Test]
        public void DecoderTest_YcoordinateException()
        {
            ATM.Decoder uut = new ATM.Decoder();

            List<string> de = new List<string>();

            de.Add("ATR423;39005;12 32;14000;20151006213456789");

            Assert.ThrowsException<FormatException>(() => uut.Decode(de));
        }

        [TestCase()]
        public void DecoderTest_AltitudeIsCorrect()
        {

            ATM.Decoder uut = new ATM.Decoder();

            List<string> de = new List<string>();

            de.Add("ATR423;39045;12932;14000;20151006213456789");

            List<IVehicle> ve = uut.Decode(de);

            var vehicle = ve.First();

            Assert.AreEqual(vehicle.Altitude, 14000);
        }

        [Test]
        public void DecoderTest_AltitudeException()
        {
            ATM.Decoder uut = new ATM.Decoder();

            List<string> de = new List<string>();

            de.Add("ATR423;39005;1232;d400;20151006213456789");

            Assert.ThrowsException<FormatException>(() => uut.Decode(de));
        }

        [TestCase()]
        public void DecoderTest_TimestampIsCorrect()
        {

            ATM.Decoder uut = new ATM.Decoder();

            List<string> de = new List<string>();

            de.Add("ATR423;39045;12932;14000;20151006213456789");

            List<IVehicle> ve = uut.Decode(de);

            var vehicle = ve.First();

            Assert.AreEqual(vehicle.Timestamp.ToFileTimeUtc(), 130886408967890000);
        }

        [Test]
        public void DecoderTest_TimestampException()
        {
            ATM.Decoder uut = new ATM.Decoder();

            List<string> de = new List<string>();

            de.Add("ATR423;39005;1232;1400;20151006");

            Assert.ThrowsException<FormatException>(() => uut.Decode(de));
        }
    }
}
