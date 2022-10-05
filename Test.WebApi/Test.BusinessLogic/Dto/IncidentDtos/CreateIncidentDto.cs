
namespace Test.BusinessLogic.Dto.IncidentDtos
{
    public class CreateIncidentDto
    {
        public string AccountName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string? Description { get; set; }
    }
}
