using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A001.Services
{
    public class EmailMessageSender : IMessageSender
    {
        public string Send()
        {
            return "Sent by Email";
        }
    }
}
