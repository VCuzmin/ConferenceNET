using Conference.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Conference.Api.Controllers
{
    [Route("api/suggestions")]
    [ApiController]
    public class SuggestionsController: ControllerBase
    {
        private readonly IMediator _mediator;

        public SuggestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetSuggestions.Query query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}