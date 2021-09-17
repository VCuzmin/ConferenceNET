using AutoMapper;
using Conference.Domain.Repositories;
using Conference.Application.Commands;
using Conference.PublishedLanguage.Events;
using MediatR;
using NBB.Messaging.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Conference.Application.CommandHandlers
{
    public class DeleteConferenceCommandHandler : IRequestHandler<DeleteConference>
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IMapper _mapper;
        private readonly IMessageBusPublisher _messageBusPublisher;

        public DeleteConferenceCommandHandler(IConferenceRepository conferenceRepository, IMapper mapper, IMessageBusPublisher messageBusPublisher)
        {
            _conferenceRepository = conferenceRepository;
            _mapper = mapper;
            _messageBusPublisher = messageBusPublisher;
        }

        public async Task<Unit> Handle(DeleteConference request, CancellationToken cancellationToken)
        {
            var db = await _conferenceRepository.GetConferenceByIdAsync(request.Id, cancellationToken);
            await _conferenceRepository.DeleteConferenceAsync(request.Id, cancellationToken);
            var @event = _mapper.Map<ConferenceDeleted>(db);
            await _messageBusPublisher.PublishAsync(@event, cancellationToken);
            return Unit.Value;
        }
    }
}