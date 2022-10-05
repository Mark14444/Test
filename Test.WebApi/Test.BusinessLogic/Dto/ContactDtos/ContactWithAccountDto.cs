
namespace Test.BusinessLogic.Dto.ContactDtos
{
    public class ContactWithAccountDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? AccountName { get; set; }
    }
}
