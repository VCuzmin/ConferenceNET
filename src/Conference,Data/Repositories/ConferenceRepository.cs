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
            var conferences = await _dbContext.ConferenceXAttendees.Where(c =>
               c.ConferenceId == conferenceId).Include(x => x.Conference).ToListAsync();

            return conferences;
        }
    }
}