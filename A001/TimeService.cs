using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A001
{
    public class TimeService
    {
        //public string GetTime() => System.DateTime.Now.ToString("hh:mm:ss");

        //public TimeService()
        //{
        //    Time = System.DateTime.Now.ToString("hh:mm:ss");
        //}
        //public string Time { get; }

        //************************

        private ITimer _timer;
        public TimeService(ITimer timer)
        {
            _timer = timer;
        }
        public string GetTime()
        {
            return _timer.Time;
        }
    }
}
