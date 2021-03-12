using RabbitMQ.Client;

namespace Core.Utilities.RabbitMQ
{
    public interface IRabbitMQService
    {
        public IConnection GetRabbitMQConnection();
    }
}