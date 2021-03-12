using RabbitMQ.Client;

namespace Core.Utilities.RabbitMQ
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly string _hostName = "localhost";
        private readonly ConnectionFactory _connectionFactory;

        public RabbitMQService()
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = _hostName
            };
        }

        public IConnection GetRabbitMQConnection()
        {           

            return _connectionFactory.CreateConnection();
        }
    }
}
