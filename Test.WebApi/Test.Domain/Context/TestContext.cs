using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Test.Domain.Entities;
using Test.Domain.Mapping;

namespace Test.Domain.Context
{
    public class TestContext:DbContext,ITestContext
    {
        public TestContext(DbContextOptions options) 
            : base(options) { }

        public DbSet<Incident> Incidents { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json");
                string connectionString = builder.Build().GetConnectionString("conn");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new IncidentMap())
                .ApplyConfiguration(new AccountMap())
                .ApplyConfiguration(new ContactMap()); 
            base.OnModelCreating(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
