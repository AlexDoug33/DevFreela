using DevFreela.Core.Services;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ConnectionFactory _factory;

        public MessageBusService()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
        }

        public void Publish(string queue, byte[] message)
        {
            using (var connecton = _factory.CreateConnection())
            {
                using (var channel = connecton.CreateModel())
                {
                    channel.QueueDeclare(
                       queue: queue,
                       durable: false,
                       exclusive: false,
                       autoDelete: false,
                       arguments: null);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: message);
                }
            }
        }
    }
}
