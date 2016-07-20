using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerWebApp.Models
{
    public class NotifyType
    {
        public string UserId { get; set; }
        public Guid InstanceId { get; set; }
        public ApplicationEventConstant EventConstant { get; set; }
        public string Data { get; set; }
    }
}