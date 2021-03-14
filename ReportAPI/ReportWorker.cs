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
 * IHostedService s�n�f�ndan implemente olan BackgroundService s�n�f�n� kullanan
 * ve RabbitMQ kuyru�undaki yay�nlar� dinleyecek olan s�n�f
 * 
 */

namespace ReportAPI
{
    public class ReportWorker : BackgroundService
    {
        private readonly ILogger<ReportWorker> _logger;
        //private HttpClient client;

        // varsay�lan kuyruk ad�
        private static readonly string _queueName = "ReportQueue";

        // publisher ve consumer ad�nda iki metoda sahip aray�z
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
            // TODO: EventBus Consumer metodu ile kuyruktan rapor istek mesaj�n� al,
            // ard�ndan ReportAPI �zerinden GenerateReport metodunu �a��r.

            string message = eventBus.Consumer(_queueName);
            //_logger.LogInformation("Message : " + message);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DoWork();

                // 5 saniye arayla �al���yor
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
