using Core.Utilities.RabbitMQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ.Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        string _queueName = "ReportQueue";

        IEventBus eventBus = new EventBus(new RabbitMQService());

        [HttpGet]
        public string Get()
        {
            return "Publisher";
            //eventBus.Publisher(_queueName, "Hello RabbitMQ World!");
            //return "Gönderilen mesaj : Hello RabbitMQ World!";
        }

        [HttpGet("RaporOlustur")]
        public void GetRapor()
        {
            eventBus.Publisher(_queueName, "Rapor oluşturma isteği alındı.");
        }

        [HttpPost]
        public void Post([FromBody] string mesaj)
        {
            eventBus.Publisher(_queueName, mesaj + "_01");
            //Thread.Sleep(200);
            //eventBus.Publisher(_queueName, mesaj + "_02");
            //Thread.Sleep(200);
            //eventBus.Publisher(_queueName, mesaj + "_03");
            //Thread.Sleep(200);
            //eventBus.Publisher(_queueName, mesaj + "_04");
            //Thread.Sleep(200);
            //eventBus.Publisher(_queueName, mesaj + "_05");
        }
    }
}
