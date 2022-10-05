using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.BusinessLogic.Dto.ContactDtos;
using Test.BusinessLogic.Services.Interfaces;
using Test.Domain.Context;
using Test.Domain.Entities;

namespace Test.BusinessLogic.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly ITestContext _context;
        private readonly IMapper _mapper;
        public ContactService(ITestContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateContactAsync(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<ContactWithAccountDto?> GetContactAsync(string email)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Email == email);
            var contactDto = _mapper.Map<ContactWithAccountDto>(contact);
            return contactDto;
        }

        public async Task<bool> UpdateContactAsync(ContactWithAccountDto contactDto)
        {
            var contact = _context.Contacts.Find(contactDto.Email);
            if(contact == null || contact.AccountName != null && contact.AccountName != contactDto.AccountName)
            {
                return false;
            }
            contact.FirstName = contactDto.FirstName;
            contact.LastName = contactDto.LastName;
            contact.AccountName = contactDto.AccountName;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> LinkAccountWithContactAsync(LinkContactDto linkContact)
        {
            var contact = await _context.Contacts.FindAsync(linkContact.Email);
            if (_context.Accounts.Any(x => x.Name == linkContact.AccountName) && contact != null && contact.AccountName == null)
            {
                contact.AccountName = linkContact.AccountName;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
