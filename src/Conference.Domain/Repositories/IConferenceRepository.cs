using Conference.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Conference.Domain.Repositories
{
    public interface IConferenceRepository
    {
        Task<List<ConferenceXAttendee>> GetConferencesAsync(int conferenceId, string atendeeEmail, CancellationToken cancellationToken = default);
        Task<List<ConferenceXAttendee>> GetConferencesAsync(string[] atendeeEmail, CancellationToken cancellationToken = default);
        Task<List<Entities.Conference>> GetConferencesAsync(int[] ids, CancellationToken cancellationToken = default);
        Task<Entities.Conference> GetConferenceByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Entities.Conference> GetConferenceByNameAsync(string name, CancellationToken cancellationToken = default);
        Task CreateConferenceAsync(Entities.Conference conference, CancellationToken cancellationToken = default);
        Task UpdateConferenceAsync(Entities.Conference conference, CancellationToken cancellationToken = default);
        Task DeleteConferenceAsync(int id, CancellationToken cancellationToken = default);
    }
}