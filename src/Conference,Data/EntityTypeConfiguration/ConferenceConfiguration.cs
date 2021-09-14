using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conference.Data.EntityTypeConfiguration
{
    public class ConferenceConfiguration : IEntityTypeConfiguration<Domain.Entities.Conference>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Conference> builder)
        {
            builder.ToTable("Conference").HasKey(x => new { x.Id });
        }
    }
}