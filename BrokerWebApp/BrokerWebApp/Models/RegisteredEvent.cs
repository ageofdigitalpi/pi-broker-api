using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerWebApp.Models
{
    public class RegisteredEvent
    {
        public string UserId { get; set; }
        public Guid InstanceId { get; set; }
        public ApplicationEventConstant EventConstant { get; set; }
        public string Action { get; set; }
    }
}