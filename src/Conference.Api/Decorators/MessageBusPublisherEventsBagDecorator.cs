using Conference.Api.Extensions;
using MediatR;
using NBB.Messaging.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Conference.Api.Decorators
{
    public class MessageBusPublisherEventsBagDecorator : IMessageBusPublisher
    {
        private readonly IMessageBusPublisher _inner;
        private readonly IEventsBagAccessor _eventsBag;

        public MessageBusPublisherEventsBagDecorator(IMessageBusPublisher inner, IEventsBagAccessor eventsBag)
        {
            _inner = inner;
            _eventsBag = eventsBag;
        }

        public Task PublishAsync<T>(T message, MessagingPublisherOptions options = null, CancellationToken cancellationToken = default)
        {
            if (message is INotification @event)
            {
                _eventsBag.Events?.Add(@event);
            }

            return _inner.PublishAsync(message, cancellationToken);
        }
    }
}