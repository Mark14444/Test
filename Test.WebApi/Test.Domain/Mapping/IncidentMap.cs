using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Domain.Mapping
{
    public class IncidentMap : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(x => x.Name);
            builder.Property(x => x.Name).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Accounts)
                .WithOne(y => y.Incident)
                .HasForeignKey(y => y.IncidentName);
        }
    }
}
