using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{

    public class Timer : ITimer
    { 
        public event EventHandler<TrackEventArgs> Expired;

        private System.Timers.Timer timer;

        private TrackEventArgs args = new TrackEventArgs();

        public Timer(int time, List<IVehicle> vehicles)
        {
            args.tracks = vehicles;

            timer = new System.Timers.Timer();
            // Bind OnTimerEvent with an object of this, and set up the event
            timer.Elapsed += (sender, e) => OnTimerEvent(sender, args);
            timer.Interval = time;
            timer.AutoReset = false;
        }


        public void Start()
        {
            timer.Enabled = true;
        }

        public void Stop()
        {
            timer.Enabled = false;
        }

        private void OnTimerEvent(object sender, TrackEventArgs args)
        {
            Expired?.Invoke(this, args);
            timer.Enabled = false;
        }

    }
}
