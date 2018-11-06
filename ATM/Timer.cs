using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{

    public class Timer : ITimer
    {
        public int TimeRemaining { get; private set; }

        public event EventHandler Expired;

        private System.Timers.Timer timer;

        public Timer(int time)
        {
            timer = new System.Timers.Timer();
            // Bind OnTimerEvent with an object of this, and set up the event
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerEvent);
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

        private void Expire()
        {
            timer.Enabled = false;
            Expired?.Invoke(this, System.EventArgs.Empty);
        }

        private void OnTimerEvent(object sender, System.Timers.ElapsedEventArgs args)
        {
            Expire();
        }

    }
}
