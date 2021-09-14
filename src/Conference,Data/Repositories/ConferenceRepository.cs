using Conference.Domain.Entities;
using Conference.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conference.Data.Repositories
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly ConferenceDbContext _dbContext;

        public ConferenceRepository(ConferenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ConferenceXAttendee>> GetConferencesAsync(int conferenceId, string atendeeEmail, CancellationToken cancellationToken = default)
        {
            var conferences = await _dbContext.ConferenceXAttendees
                .Where(c => c.ConferenceId == conferenceId && c.AttendeeEmail != atendeeEmail && c.StatusId == Status.Joined.Id)
                // .Include(x => x.Conference)
                .ToListAsync(cancellationToken);

            return conferences;
        }

        public async Task<List<ConferenceXAttendee>> GetConferencesAsync(string[] atendeeEmails, CancellationToken cancellationToken = default)
        {
            var conferences = await _dbContext.ConferenceXAttendees
                .Where(c => atendeeEmails.Contains(c.AttendeeEmail) && c.StatusId == Status.Joined.Id)
                .Include(x => x.Conference)
                .ToListAsync(cancellationToken);

            return conferences;
        }

        public async Task<List<Domain.Entities.Conference>> GetConferencesAsync(int[] ids, CancellationToken cancellationToken = default)
        {
            var conferences = await _dbContext.Conferences
                .Where(c => ids.Contains(c.Id))
                .ToListAsync(cancellationToken);

            return conferences.ToList();
        }

        public async Task CreateConferenceAsync(Domain.Entities.Conference conference, CancellationToken cancellationToken = default)
        {
            _dbContext.Conferences.Add(conference);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Domain.Entities.Conference> GetConferenceByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var conference = await _dbContext.Conferences
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            return conference;
        }

        public async Task UpdateConferenceAsync(Domain.Entities.Conference conference, CancellationToken cancellationToken = default)
        {
            _dbContext.Conferences.Update(conference);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteConferenceAsync(int id, CancellationToken cancellationToken = default)
        {
            var conference = await _dbContext.Conferences
                    .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            _dbContext.Conferences.Remove(conference);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Domain.Entities.Conference> GetConferenceByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var conference = await _dbContext.Conferences
                    .FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
            return conference;
        }
    }
}