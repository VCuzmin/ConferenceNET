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
        public class Query : Query<List<Domain.Entities.Conference>>
        {
            public string AttendeeEmail { get; set; }
            public int ConferenceId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, List<Domain.Entities.Conference>>
        {
            private readonly IConferenceRepository _repository;

            public QueryHandler(IConferenceRepository repository)
            {
                _repository = repository;
            }

            public async Task<List<Domain.Entities.Conference>> Handle(Query request, CancellationToken cancellationToken)
            {
                var conferences = await _repository.GetConferences(request.ConferenceId, request.AttendeeEmail);
                var attendeeEmails = conferences.Select(x => x.AttendeeEmail).ToArray();

                var otherConferences = await _repository.GetConferences(attendeeEmails);

                var listOfRecommendedConferences = otherConferences
                    .Where(c => c.ConferenceId != request.ConferenceId)
                    //.Select(c => c.ConferenceId)
                    .ToList();

                var ids = listOfRecommendedConferences.GroupBy(v => v.ConferenceId)
                    .ToDictionary(x => x.Key, y => y.Count())
                    .OrderByDescending(d => d.Value)
                    .Take(3)
                    .Select(keyValuePair => keyValuePair.Key)
                    .ToArray();


                return await _repository.GetConferences(ids);
            }
        }
    }
}