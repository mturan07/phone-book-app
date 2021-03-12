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
            return "Gelen mesaj : " + eventBus.Consumer(_queueName);
        }
    }
}
