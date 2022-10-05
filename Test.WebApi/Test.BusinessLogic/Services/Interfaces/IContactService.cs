using Test.BusinessLogic.Dto.ContactDtos;

namespace Test.BusinessLogic.Services.Interfaces
{
    public interface IContactService
    {
        Task CreateContactAsync(ContactDto contact);
        Task<bool> UpdateContactAsync(ContactWithAccountDto contact);
        Task<bool> LinkAccountWithContactAsync(LinkContactDto linkContact);
        Task<ContactWithAccountDto?> GetContactAsync(string email);
    }
}
