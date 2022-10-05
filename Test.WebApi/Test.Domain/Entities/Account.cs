
namespace Test.Domain.Entities
{
    public class Account
    {
        public string Name { get; set; } = null!;
        public string? IncidentName { get; set; }
        public Incident? Incident { get; set; }
        public ICollection<Contact> Contacts { get; set; } = null!;
    }
}
