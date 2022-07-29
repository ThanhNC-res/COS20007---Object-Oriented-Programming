using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Clock
    {

        private Counter _hrs;
        private Counter _mins;
        private Counter _secs;

        public Clock()
        {
            _hrs = new Counter("Hours", 0);
            _mins = new Counter("Minutes", 0);
            _secs = new Counter("Seconds", 0);
        }

        public int Hours
        {
            get
            {
                return _hrs.Count;
            }
        }

        public int Minutes
        {
            get
            {
                return _mins.Count;
            }
        }

        public int Seconds
        {
            get
            {
                return _secs.Count;
            }
        }
        public string ClockFormat()
        {
            return string.Format("{0}:{1:00}:{2:00}", Hours, Minutes, Seconds);

        }
        public void Resetclock()
        {
            _hrs.ResetCount();
            _mins.ResetCount();
            _secs.ResetCount();
        }

        public void Tick()
        {
            _secs.CountIncre();
            if (Seconds >= 60)
            {
                _secs.ResetCount();
                _mins.CountIncre();
                if (Minutes >= 60)
                {
                    _mins.ResetCount();
                    _hrs.CountIncre();
                    if (Hours >= 24)
                    {
                        Resetclock();
                    }
                }
            }
        }

       

    }
}
