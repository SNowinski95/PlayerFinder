using System.Text;
using RabbitMQ.Client;

namespace Common.Rabbit;

public class Sender(string hostName)
{
    private bool _disposed; 
    private ConnectionFactory _factory = new() { HostName = hostName };

    public async Task SendMessageAsync(string queueName, string message, string key)
    {
        if (_factory is null) throw new InvalidOperationException("Factory is not initialized");
        await using var connection = await _factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var body = Encoding.UTF8.GetBytes(message);
        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: key, body: body);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        _factory = null;
        _disposed = true;
    }
}