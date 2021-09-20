using Conference.Api.Extensions;
using Conference.PublishedLanguage.Events;
using MediatR.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Conference.Api.MediatorPipeline
{
    public class CustomRequestExceptionHandler<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
        where TRequest : notnull
        where TException : Exception
    {
        private readonly IEventsBagAccessor _eventsBag;

        public CustomRequestExceptionHandler(IEventsBagAccessor eventsBag)
        {
            _eventsBag = eventsBag;
        }

        public Task Handle(TRequest request,
            TException exception,
            RequestExceptionHandlerState<TResponse> state,
            CancellationToken cancellationToken)
        {
            _eventsBag.Events.Add(new RequestExecutionError<TRequest>(request, exception));
            return Task.CompletedTask;
        }
    }
}