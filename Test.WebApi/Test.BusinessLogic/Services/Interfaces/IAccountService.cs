using Test.BusinessLogic.Dto.AccountDtos;

namespace Test.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> LinkAccountWithIncidentAsync(LinkAccountDto linkAccount);
        Task CreateAccountAsync(CreateAccountDto account);
        Task<AccountDto?> GetAccountAsync(string accountName);
    }
}
