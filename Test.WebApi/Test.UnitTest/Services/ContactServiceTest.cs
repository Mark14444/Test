using FluentAssertions;
using FluentAssertions.Execution;
using System.Threading.Tasks;
using Test.BusinessLogic.Dto.AccountDtos;
using Test.BusinessLogic.Dto.ContactDtos;
using Test.BusinessLogic.Services.Implementation;
using Test.BusinessLogic.Services.Interfaces;
using Test.Domain.Context;
using Test.Domain.Entities;
using Test.UnitTest.Base;
using Xunit;

namespace Test.UnitTest.Services
{
    public class ContactServiceTest:Base.Base
    {
        private readonly IContactService service;
        private readonly TestContext context;
        public ContactServiceTest()
        {
            context = ContextGenerator.GetContext();
            service = new ContactService(context,Mapper);
        }

        [Theory]
        [AutoEntityData]
        public async Task CreateContact_WhenContactIsValid_AddsToDb(ContactDto contact)
        {
            //Arrange

            // Act
            await service.CreateContactAsync(contact);
            var result = await context.Contacts.FindAsync(contact.Email);

            // Assert
            result.Should().NotBeNull();
        }

        [Theory]
        [AutoEntityData]
        public async Task GetContactAsync_WhenContactExists_ReturnsContact(ContactDto contact)
        {
            //Arrange
            await service.CreateContactAsync(contact);

            // Act
            var result = await service.GetContactAsync(contact.Email);

            // Assert
            result.Should().BeEquivalentTo(contact);
        }

        [Theory]
        [AutoEntityData]
        public async Task UpdateContactAsync_WhenContactExists_ChangesContact(ContactWithAccountDto contact)
        {
            //Arrange
            await service.CreateContactAsync(new ContactDto { Email = contact.Email,
                                                              FirstName = contact.FirstName,
                                                              LastName = contact.LastName});
            contact.FirstName = "test";
            contact.LastName = "test";

            // Act
            var result = await service.UpdateContactAsync(contact);
            var check = await service.GetContactAsync(contact.Email);

            // Assert
            using(new AssertionScope())
            {
                result.Should().Be(true);
                contact.Should().BeEquivalentTo(check);
            }
        }
        [Theory]
        [AutoEntityData]
        public async Task UpdateContactAsync_WhenContactDoesNotExists_ReturnsFalse(ContactWithAccountDto contact)
        {
            //Arrange

            // Act
            var result = await service.UpdateContactAsync(contact);

            // Assert
            result.Should().Be(false);
        }

        [Theory]
        [AutoEntityData]
        public async Task LinkAccountWithContactAsync_WhenAccountAndContactExist_LinksTwoEntities(AccountDto accountDto,ContactDto contactDto)
        {
            //Arrange
            var account = Mapper.Map<Account>(accountDto);
            var contact = Mapper.Map<Contact>(contactDto);
            context.Accounts.Add(account);
            context.Contacts.Add(contact);
            context.SaveChanges();

            // Act
            var result = await service.LinkAccountWithContactAsync(new LinkContactDto { AccountName = accountDto.Name,
                                                                                        Email = contactDto.Email});

            // Assert
            result.Should().Be(true);
        }
    }
}
