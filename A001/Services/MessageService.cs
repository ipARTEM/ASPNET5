using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A001.Services
{
    public class MessageService
    {

        IMessageSender _sender;
        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }
        public string Send()
        {
            return _sender.Send();
        }
    }
}
