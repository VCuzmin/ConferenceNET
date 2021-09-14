using MediatR;
using System.Collections.Generic;
using System.Threading;

namespace Conference.Api.Extensions
{
    public class EventsBagAccessor : IEventsBagAccessor
    {
        private static readonly AsyncLocal<List<INotification>> AsyncLocal = new();

        public List<INotification> Events
        {
            set => AsyncLocal.Value = value;
            get => AsyncLocal.Value;
        }
    }

    public interface IEventsBagAccessor
    {
        List<INotification> Events { set; get; }
    }
}