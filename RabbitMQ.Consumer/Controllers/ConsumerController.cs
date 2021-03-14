using Core.Utilities.RabbitMQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private static readonly string _queueName = "ReportQueue";

        IEventBus eventBus = new EventBus(new RabbitMQService());

        [HttpGet]
        public string Get()
        {
            List<string> messages = new List<string>();
            messages = eventBus.Consumer(_queueName);
            
            string str = "";

            foreach (string item in messages)
            {
                str += item;
            }

            return "Consumer" + "\n" +
                "Mesajlar : " + str;
        }
    }
}
