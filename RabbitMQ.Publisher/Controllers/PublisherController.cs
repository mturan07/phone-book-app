using Core.Utilities.RabbitMQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ.Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private static readonly string _queueName = "ReportQueue";

        IEventBus eventBus = new EventBus(new RabbitMQService());

        [HttpGet]
        public string Get()
        {
            eventBus.Publisher(_queueName, "Hello RabbitMQ World!");
            return "Gönderilen mesaj : Hello RabbitMQ World!";
        }

        [HttpPost]
        public void Post([FromBody] string mesaj)
        {
            eventBus.Publisher(_queueName, mesaj);
        }
    }
}
