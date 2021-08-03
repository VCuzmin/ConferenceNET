using Conference.Data.EntityTypeConfiguration;
using Conference.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Conference.Data
{
    public class ConferenceDbContext : DbContext
    {
        public DbSet<Domain.Entities.Conference> Conferences { get; set; }
        public DbSet<ConferenceXAttendee> ConferenceXAttendees { get; set; }

        public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ConferenceXAttendeeConfiguration());
            modelBuilder.ApplyConfiguration(new ConferenceConfiguration());
        }
    }
}