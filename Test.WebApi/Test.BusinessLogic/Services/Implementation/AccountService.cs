using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.BusinessLogic.Dto.AccountDtos;
using Test.BusinessLogic.Services.Interfaces;
using Test.Domain.Context;
using Test.Domain.Entities;

namespace Test.BusinessLogic.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly ITestContext _context;
        private readonly IMapper _mapper;
        public AccountService(ITestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateAccountAsync(CreateAccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            var contact = await _context.Contacts.SingleOrDefaultAsync(x => x.Email == accountDto.ContactEmail);
            if(_context.Accounts.Any(x => x.Name == account.Name)||contact == null)
            {
                return;
            }
            account.Contacts = new HashSet<Contact>() { contact};
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> LinkAccountWithIncidentAsync(LinkAccountDto linkAccount)
        {
            var account = await _context.Accounts.FindAsync(linkAccount.AccountName);
            if (_context.Accounts.Any(x => x.Name == linkAccount.AccountName) && account != null && account.IncidentName == null)
            {
                account.IncidentName = linkAccount.IncidentName;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<AccountDto?> GetAccountAsync(string accountName)
        {
            var account = await _context.Accounts.Include(x => x.Contacts).SingleOrDefaultAsync(y => y.Name == accountName);
            var accountDto = _mapper.Map<AccountDto>(account);
            return accountDto;
        }

    }
}
