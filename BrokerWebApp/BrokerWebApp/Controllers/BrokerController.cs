using BrokerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BrokerWebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BrokerController : ApiController
    {
        static List<RegisteredEvent> _events = new List<RegisteredEvent>();
        static List<EventNotification> _notifications = new List<EventNotification>();

        public IHttpActionResult Register([FromBody] RegisteredEvent eventToRegister)
        {
            if(eventToRegister == null)
            {
                return BadRequest();
            }

            DoUnRegister(eventToRegister.InstanceId, eventToRegister.EventConstant);

            _events.Add(eventToRegister);

            return Ok();
        }

        public IHttpActionResult UnRegister([FromBody] UnRegisterType unRegister)
        {
            DoUnRegister(unRegister.InstanceId, unRegister.EventConstant);

            return Ok();
        }

        public IHttpActionResult Notify([FromBody] NotifyType notifyData)
        {
            foreach (RegisteredEvent evt in _events.Where(e =>
                e.InstanceId != notifyData.InstanceId && e.UserId == notifyData.UserId && e.EventConstant == notifyData.EventConstant))
            {
                _notifications.Add(new EventNotification { RegEvent = evt, Data = notifyData.Data });
            }

            return Ok();
        }

        public IHttpActionResult Poll([FromBody] PollType pollData)
        {
            List<EventNotification> events = _notifications.Where(n => n.RegEvent.InstanceId == pollData.InstanceId).ToList();

            foreach(var evt in events)
            {
                _notifications.Remove(evt);
            }
            ;
            return Ok(events.Select(e => new Tuple<string, string>(e.RegEvent.Action, e.Data)));
        }

        private void DoUnRegister(Guid instanceId, ApplicationEventConstant eventConstant)
        {

            RegisteredEvent registeredEvent = _events.SingleOrDefault(e =>
                e.InstanceId == instanceId &&
                e.EventConstant == eventConstant);

            if(registeredEvent == null)
            {
                return;
            }

            _events.Remove(registeredEvent);
        }
    }
}
