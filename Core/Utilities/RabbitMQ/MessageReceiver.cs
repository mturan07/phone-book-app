﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.RabbitMQ
{
    public class MessageReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;
        private readonly string _receivedMessage = "";
        public MessageReceiver(IModel channel)
        {
            _channel = channel;
        }

        //public override void HandleBasicDeliver(
        //    string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, 
        //    IBasicProperties properties, ReadOnlyMemory<byte> body)
        //{
        //    Console.WriteLine($"Consuming Message");

        //    Console.WriteLine(string.Concat("Message received from the exchange ", exchange));

        //    Console.WriteLine(string.Concat("Consumer tag: ", consumerTag));

        //    Console.WriteLine(string.Concat("Delivery tag: ", deliveryTag));

        //    Console.WriteLine(string.Concat("Routing tag: ", routingKey));

        //    Console.WriteLine(string.Concat("Message: ", Encoding.UTF8.GetString(body.ToArray())));

        //    _channel.BasicAck(deliveryTag, false);
        //}


        public override void HandleBasicDeliver(
            string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey,
            IBasicProperties properties, ReadOnlyMemory<byte> body)
        {
            Console.WriteLine($"Consuming Message");

            Console.WriteLine(string.Concat("Message received from the exchange ", exchange));

            Console.WriteLine(string.Concat("Consumer tag: ", consumerTag));

            Console.WriteLine(string.Concat("Delivery tag: ", deliveryTag));

            Console.WriteLine(string.Concat("Routing tag: ", routingKey));

            Console.WriteLine(string.Concat("Message: ", Encoding.UTF8.GetString(body.ToArray())));

            _channel.BasicAck(deliveryTag, false);
        }

        public string getReceivedMessage()
        {
            return _receivedMessage;
        }
    }
}
