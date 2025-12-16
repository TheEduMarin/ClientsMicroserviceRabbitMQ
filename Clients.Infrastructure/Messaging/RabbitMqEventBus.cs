
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Clients.Infrastructure.Messaging
{
    public class RabbitMqEventBus : IEventBus
    {
        private readonly IConnection _connection;

        public RabbitMqEventBus()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            _connection = factory.CreateConnection();
        }

        public void Publish<T>(T @event)
        {
            using var channel = _connection.CreateModel();
            channel.ExchangeDeclare("clientes.exchange", ExchangeType.Topic, durable: true);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event));

            channel.BasicPublish(
                exchange: "clientes.exchange",
                routingKey: "cliente.creado",
                basicProperties: null,
                body: body
            );
        }
    }
}
