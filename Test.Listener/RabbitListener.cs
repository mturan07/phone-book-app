// RabbitListener.cs is the base class, which only implements the Process of registering RabbitMQ and listening to messages, and then each consumer rewrites the RouteKey/QueueName / message processing function

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


namespace Test.Listener
{
    public class RabbitListener : IHostedService
    {

        private readonly IConnection connection;
        private readonly IModel channel;


        public RabbitListener(IOptions<AppConfiguration> options)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    // This is my configuration. Just change it to my own use
                    HostName = options.Value.RabbitHost,
                    UserName = options.Value.RabbitUserName,
                    Password = options.Value.RabbitPassword,
                    Port = options.Value.RabbitPort,
                };
                this.connection = factory.CreateConnection();
                this.channel = connection.CreateModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RabbitListener init error,ex:{ex.Message}");
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Register();
            return Task.CompletedTask;
        }


        protected string RouteKey;
        protected string QueueName;

        // How to process messages
        public virtual bool Process(string message)
        {
            throw new NotImplementedException();
        }

        // Registered consumer monitoring here
        public void Register()
        {
            Console.WriteLine($"RabbitListener register,routeKey:{RouteKey}");
            channel.ExchangeDeclare(exchange: "message", type: "topic");
            channel.QueueDeclare(queue: QueueName, exclusive: false);
            channel.QueueBind(queue: QueueName,
                              exchange: "message",
                              routingKey: RouteKey);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                var result = Process(message);
                if (result)
                {
                    channel.BasicAck(ea.DeliveryTag, false);
                }
            };
            channel.BasicConsume(queue: QueueName, consumer: consumer);
        }

        public void DeRegister()
        {
            this.connection.Close();
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.connection.Close();
            return Task.CompletedTask;
        }
    }

}