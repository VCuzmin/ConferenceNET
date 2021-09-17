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
    public class CreateConferenceCommandHandler : IRequestHandler<CreateConference>
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IMapper _mapper;
        private readonly IMessageBusPublisher _messageBusPublisher;

        public CreateConferenceCommandHandler(IConferenceRepository conferenceRepository, IMapper mapper, IMessageBusPublisher messageBusPublisher)
        {
            _conferenceRepository = conferenceRepository;
            _mapper = mapper;
            _messageBusPublisher = messageBusPublisher;
        }

        public async Task<Unit> Handle(CreateConference request, CancellationToken cancellationToken)
        {
            var db = _mapper.Map<Domain.Entities.Conference>(request);
            await _conferenceRepository.CreateConferenceAsync(db, cancellationToken);
            var @event = _mapper.Map<ConferenceCreated>(db);
            await _messageBusPublisher.PublishAsync(@event, cancellationToken);
            return Unit.Value;
        }
    }
}