using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Utilities.RabbitMQ
{
    public interface IEventBus
    {
        public void Publisher(string queueName, string message);

        public string Consumer(string queueName);
    }
}
