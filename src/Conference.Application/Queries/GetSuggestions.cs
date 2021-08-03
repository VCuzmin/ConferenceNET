using AutoMapper;
using Conference.Domain.Repositories;
using MediatR;
using NBB.Application.DataContracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conference.Application.Queries
{
    public class GetSuggestions
    {
        public class Query : Query<List<string>>
        {
            public string AttendeeEmail { get; set; }
            public int ConferenceId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, List<string>>
        {

            private readonly IConferenceRepository _repository;

            public QueryHandler(IConferenceRepository repository)
            {
                _repository = repository;
            }

            public async Task<List<string>> Handle(Query request, CancellationToken cancellationToken)
            {
                var conferences = await _repository.GetConferences(request.ConferenceId, request.AttendeeEmail);
                return conferences.Select(x => x.Conference.Name).ToList();
            }
        }
    }
}