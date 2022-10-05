using Microsoft.EntityFrameworkCore;
using Test.Domain.Entities;

namespace Test.Domain.Context
{
    public interface ITestContext
    {
        DbSet<Incident> Incidents { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<Contact> Contacts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
