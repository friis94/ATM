﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ATMController : IController
    {

        public event EventHandler SeperationEventHandler;
        private ISeparationDetector _separationDetector;
        private List<IVehicle> vehicles;
        private List<ISeparation> seperations;
        


        public ATMController()
        {
            
            this._separationDetector = new SeparationDetector();
            _separationDetector.SeperationEvent += Update;
            
        }




        public void Update(object source, EventArgs args)
        {
            
        }

    }
}
