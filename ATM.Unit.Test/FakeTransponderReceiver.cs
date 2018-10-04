using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using System.Threading;

namespace ATM.Unit.Test
{
    public class FakeTransponderReceiver : ITransponderReceiver
    {
        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;
        private RawTransponderDataEventArgs args;
        private List<String> Airplanes;


        public FakeTransponderReceiver()
        {
            this.Airplanes = new List<string>();
            args = new RawTransponderDataEventArgs(Airplanes);

        }

        public void transpondCollidingAirplanes()
        {
            Airplanes.Add("ATR423;39040;12900;14000;20151006213456789");
            Airplanes.Add("DAT424;39045;12932;13800;20151006213456789");
            TransponderDataReady?.Invoke(this, args);
            
        }


        public void transpondNotCollidingAirplanes()
        {
            Airplanes.Add("ATR423;39045;12932;14000;20151006213456789");
            Airplanes.Add("DAT424;10000;20000;1000;20151006213456789");
            TransponderDataReady?.Invoke(this, args);

        }

        public void transpondNoAirplanes()
        {
            Airplanes.Clear();
            TransponderDataReady?.Invoke(this, args);
        }
    }
}
