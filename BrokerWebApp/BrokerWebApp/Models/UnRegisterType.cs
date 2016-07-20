using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerWebApp.Models
{
    public class UnRegisterType
    {
        public Guid InstanceId { get; set; }
        public ApplicationEventConstant EventConstant { get; set; }
    }
}