using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerWebApp.Models
{
    public class EventNotification
    {
        public RegisteredEvent RegEvent { get; set; }
        public string Data { get; set; }
    }
}