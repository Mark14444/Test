using Test.BusinessLogic.Dto.AccountDtos;

namespace Test.BusinessLogic.Dto.IncidentDtos
{
    public class IncidentDto
    {
        public string Name { get; set; } = null!;
        public ICollection<AccountDto> Accounts { get; set; } = null!;
        public string? Description { get; set; }
    }
}
