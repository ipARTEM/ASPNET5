using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A001.Services
{
    public class CounterService
    {
        protected internal ICounter Counter { get; }
        public CounterService(ICounter counter)
        {
            Counter = counter;
        }
    }
}
