using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.RabbitMQ;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

/**
 * ReportWorker:
 * 
 * IHostedService sýnýfýndan implemente olan BackgroundService sýnýfýný kullanan
 * ve RabbitMQ kuyruðundaki yayýnlarý dinleyecek olan sýnýf
 * 
 */

namespace ReportAPI
{
    public class ReportWorker : BackgroundService
    {
        private readonly ILogger<ReportWorker> _logger;
        //private HttpClient client;

        // varsayýlan kuyruk adý
        private static readonly string _queueName = "ReportQueue";

        // publisher ve consumer adýnda iki metoda sahip arayüz
        IEventBus eventBus = new EventBus(new RabbitMQService());

        public ReportWorker(ILogger<ReportWorker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("The service has been stopped...");
            return base.StopAsync(cancellationToken);
        }

        private void DoWork()
        {
            // TODO: EventBus Consumer metodu ile kuyruktan rapor istek mesajýný al,
            // ardýndan ReportAPI üzerinden GenerateReport metodunu çaðýr.

            string message = eventBus.Consumer(_queueName);
            //_logger.LogInformation("Message : " + message);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DoWork();

                // 5 saniye arayla çalýþýyor
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
