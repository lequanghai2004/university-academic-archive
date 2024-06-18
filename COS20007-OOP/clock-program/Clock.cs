
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Clock
    {
        private Counter _sec = new Counter("sec");
        private Counter _min = new Counter("min");
        private Counter _hour = new Counter("hour");
        public Clock() { }
        public string ShowTime
        {
            get
            {
                return _hour.Ticks.ToString("00") 
                    + ":" + _min.Ticks.ToString("00") 
                    + ":" + _sec.Ticks.ToString("00");
            }
        }
        public void Tick()
        {
            if (_sec.Ticks == 59)
            {
                if (_min.Ticks == 59)
                {
                    if (_hour.Ticks == 23) _hour.Reset();
                    else _hour.Increment();
                    _min.Reset();
                }
                else _min.Increment();
                _sec.Reset();
            }
            else _sec.Increment();
        }
    }
}
