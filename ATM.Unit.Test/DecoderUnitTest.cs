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

            List<IVehicle> ve = uut.Decode(de);

            var vehicle = ve.First();

            Assert.AreEqual(vehicle.Tag, "ATR423");
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

       
    }
}
