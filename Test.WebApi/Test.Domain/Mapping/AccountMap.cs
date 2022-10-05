using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Domain.Mapping
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Name);

            builder.HasMany(x => x.Contacts)
                .WithOne(y => y.Account)
                .HasForeignKey(y => y.AccountName);
        }
    }
}
