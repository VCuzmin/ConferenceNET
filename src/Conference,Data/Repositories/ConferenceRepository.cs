using Conference.Domain.Entities;
using Conference.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<ConferenceXAttendee>> GetConferences(int conferenceId, string atendeeEmail)
        {
            var conferences = await _dbContext.ConferenceXAttendees
                .Where(c => c.ConferenceId == conferenceId && c.AttendeeEmail != atendeeEmail && c.StatusId == Status.Attended.Id)
                // .Include(x => x.Conference)
                .ToListAsync();

            return conferences;
        }

        public async Task<List<ConferenceXAttendee>> GetConferences(params string[] atendeeEmails)
        {
            var conferences = await _dbContext.ConferenceXAttendees
                .Where(c => atendeeEmails.Contains(c.AttendeeEmail) && c.StatusId == Status.Attended.Id)
                .Include(x => x.Conference)
                .ToListAsync();

            return conferences;
        }

        public async Task<List<Domain.Entities.Conference>> GetConferences(params int[] ids)
        {
            var conferences = await _dbContext.Conferences
                .Where(c => ids.Contains(c.Id))
                .ToListAsync();

            return conferences.ToList();
        }
    }
}