
namespace Test.BusinessLogic.Dto.AccountDtos
{
    public class CreateAccountDto
    {
        public string Name { get; set; } = null!;
        public string? IncidentName { get; set; }
        public string ContactEmail { get; set; } = null!;
    }
}
