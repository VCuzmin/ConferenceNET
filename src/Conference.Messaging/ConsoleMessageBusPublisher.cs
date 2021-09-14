using NBB.Messaging.Abstractions;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Conference.Messaging
{
    public class ConsoleMessageBusPublisher : IMessageBusPublisher
    {
        public Task PublishAsync<T>(T message, MessagingPublisherOptions options = null, CancellationToken cancellationToken = default)
        {
            var json = JsonConvert.SerializeObject(message);
            Console.WriteLine(json);
            return Task.CompletedTask;
        }
    }
}
