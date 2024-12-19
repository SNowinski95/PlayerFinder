using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Common.Rabbit;

public class Consumer(string hostName)
{
    private bool _disposed;
    private ConnectionFactory _factory = new() { HostName = hostName };

    public async Task ConsumeMessageAsync(string queueName, string message, string key, AsyncEventHandler<BasicDeliverEventArgs> consumEventHandler)
    {
        if (_factory is null) throw new InvalidOperationException("Factory is not initialized");
        await using var connection = await _factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();
        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += consumEventHandler;
        // += (model, ea) =>
        //{
        //    byte[] body = ea.Body.ToArray();
        //    var message = Encoding.UTF8.GetString(body);
        //    Console.WriteLine($" [x] {message}");
        //    return Task.CompletedTask;
        //};
        await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer);
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