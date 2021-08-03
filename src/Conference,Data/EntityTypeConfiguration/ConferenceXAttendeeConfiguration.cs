using Conference.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conference.Data.EntityTypeConfiguration
{
    public class ConferenceXAttendeeConfiguration : IEntityTypeConfiguration<ConferenceXAttendee>
    {
        public void Configure(EntityTypeBuilder<ConferenceXAttendee> builder)
        {
            builder.ToTable("ConferenceXAttendee").HasKey(x => new { x.Id });
            builder.Property(c => c.AttendeeEmail);
            builder.Property(c => c.StatusId);
            builder.HasOne(c => c.Conference)
                .WithMany()
                .HasForeignKey(c => c.ConferenceId); ;
        }
    }
}