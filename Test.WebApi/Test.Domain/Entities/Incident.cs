
namespace Test.Domain.Entities
{
    public class Incident
    {
        public string Name { get; set; } = null!;
        public ICollection<Account> Accounts { get; set; } = null!;
        public string? Description { get; set; }
    }
}
