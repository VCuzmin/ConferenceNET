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
    public class UpdateConferenceCommandHandler : IRequestHandler<UpdateConference>
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IMapper _mapper;
        private readonly IMessageBusPublisher _messageBusPublisher;

        public UpdateConferenceCommandHandler(IConferenceRepository conferenceRepository, IMapper mapper, IMessageBusPublisher messageBusPublisher)
        {
            _conferenceRepository = conferenceRepository;
            _mapper = mapper;
            _messageBusPublisher = messageBusPublisher;
        }

        public async Task<Unit> Handle(UpdateConference request, CancellationToken cancellationToken)
        {
            var db = await _conferenceRepository.GetConferenceByIdAsync(request.Id, cancellationToken);
            db = _mapper.Map(request, db);
            await _conferenceRepository.UpdateConferenceAsync(db, cancellationToken);
            var @event = _mapper.Map<ConferenceUpdated>(db);
            await _messageBusPublisher.PublishAsync(@event, cancellationToken);
            return Unit.Value;
        }
    }
}