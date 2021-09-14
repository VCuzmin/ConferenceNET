using Conference.Api.Extensions;
using Conference.Application.Queries;
using Conference.PublishedLanguage.Commands;
using Conference.PublishedLanguage.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conference.Api.Controllers
{
    [Route("api/suggestions")]
    [ApiController]
    public class SuggestionsController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEventsBagAccessor _eventsBagAccessor;

        public SuggestionsController(IMediator mediator, IEventsBagAccessor eventsBagAccessor)
        {
            _mediator = mediator;
            _eventsBagAccessor = eventsBagAccessor;
        }

        [HttpGet("List")]
        public async Task<List<Domain.Entities.Conference>> Get([FromQuery] GetSuggestions.Query query)
        {
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost("Create")]
        public async Task<SyncCommandResult<ConferenceCreated>> Create([FromBody] CreateConference command)
        {
            await _mediator.Send(command);

            var @successEvent = _eventsBagAccessor.Events.OfType<ConferenceCreated>().FirstOrDefault();

            var returnVal = new SyncCommandResult<ConferenceCreated>(@successEvent, string.Empty);
            return returnVal;

        }

        [HttpPut("Update")]
        public async Task<SyncCommandResult<ConferenceUpdated>> Update([FromBody] UpdateConference command)
        {
            await _mediator.Send(command);

            var @successEvent = _eventsBagAccessor.Events.OfType<ConferenceUpdated>().FirstOrDefault();

            var returnVal = new SyncCommandResult<ConferenceUpdated>(@successEvent, string.Empty);
            return returnVal;

        }

        [HttpDelete("Delete")]
        public async Task<SyncCommandResult<ConferenceDeleted>> Delete([FromBody] DeleteConference command)
        {
            await _mediator.Send(command);

            var @successEvent = _eventsBagAccessor.Events.OfType<ConferenceDeleted>().FirstOrDefault();

            var returnVal = new SyncCommandResult<ConferenceDeleted>(@successEvent, string.Empty);
            return returnVal;

        }
    }
}