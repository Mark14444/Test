using Test.BusinessLogic.Dto.ContactDtos;

namespace Test.BusinessLogic.Dto.AccountDtos
{
    public class AccountDto
    {
        public string Name { get; set; } = null!;
        public string? IncidentName { get; set; }
        public ICollection<ContactDto> Contacts { get; set; } = null!;
    }
}
