using Core.Utilities.RabbitMQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        string _queueName = "ReportQueue";
        IEventBus eventBus = new EventBus(new RabbitMQService());

        [HttpGet("RaporOlustur")]
        public void GetRapor()
        {
            // RabbitMQ üzerindeki ReportQueue kuyruna rapor isteği atıyoruz
            // TODO: refactor edilecek, ilgili rapor ait belirteç eklenecek
            eventBus.Publisher(_queueName, "Rapor oluşturma isteği alındı.");
        }
    }
}
