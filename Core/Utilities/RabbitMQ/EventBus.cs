using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.RabbitMQ
{
    public class EventBus : IEventBus
    {
        RabbitMQService _rabbitMQService;

        public EventBus(RabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        public string Consumer(string queueName)
        {
            string Message = "";
            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);

                    // Received event'i sürekli listen modunda olacaktır.
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        //Console.WriteLine("{0} isimli queue üzerinden gelen mesaj: \"{1}\"", queueName, message);

                        Message = message;
                    };

                    channel.BasicConsume(queueName, true, consumer);
                    //Console.ReadLine();
                }
            }
            return Message;
        }

        public void Publisher(string queueName, string message)
        {
            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);

                    channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(message));

                    //Console.WriteLine("{0} queue'su üzerine, \"{1}\" mesajı yazıldı.", queueName, message);
                }
            }
        }
    }
}
