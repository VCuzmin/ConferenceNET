using MediatR;
using System;

namespace Conference.PublishedLanguage.Events
{
    public class RequestExecutionError<TMessage>: INotification
    {
        public TMessage OriginalRequest { get; set; }
        public Exception Error { get; set; }

        public RequestExecutionError(TMessage originalRequest, Exception error)
        {
            OriginalRequest = originalRequest;
            Error = error;
        }

    }
}