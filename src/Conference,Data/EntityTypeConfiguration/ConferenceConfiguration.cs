using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conference.Data.EntityTypeConfiguration
{
    public class ConferenceConfiguration : IEntityTypeConfiguration<Domain.Entities.Conference>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Conference> builder)
        {
            builder.ToTable("Conference").HasKey(x => new { x.Id });
            builder.Property(c => c.OrganizerEmail);
            builder.Property(c => c.Name);
            builder.Property(c => c.StartDate);
            builder.Property(c => c.EndDate);
        }
    }
}