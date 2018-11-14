using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface ITimer
    {
        event EventHandler<TrackEventArgs> Expired;

        void Start();
        void Stop();
    }
}
