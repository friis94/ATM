﻿using System;
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

        private TrackEventArgs trackEventArgs = new TrackEventArgs();

        public Timer(int time, List<IVehicle> vehicles)
        {
            trackEventArgs.tracks = vehicles;

            timer = new System.Timers.Timer();
            // Bind OnTimerEvent with an object of this, and set up the event
            timer.Elapsed += (sender, e) => OnTimerEvent(sender, trackEventArgs);
            timer.Interval = time;
            timer.AutoReset = false;
        }


        public void Start()
        {
            timer.Enabled = true;
        }


        private void OnTimerEvent(object sender, TrackEventArgs args)
        {
            Expired?.Invoke(this, args);
            timer.Enabled = false;
        }

    }
}
