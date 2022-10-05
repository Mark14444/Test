using FluentAssertions;
using System.Threading.Tasks;
using Test.BusinessLogic.Dto.AccountDtos;
using Test.BusinessLogic.Services.Implementation;
using Test.BusinessLogic.Services.Interfaces;
using Test.Domain.Context;
using Test.Domain.Entities;
using Test.UnitTest.Base;
using Xunit;

namespace Test.UnitTest.Services
{
    public class AccountServiceTest : Base.Base
    {
        private readonly IAccountService service;
        private readonly TestContext context;
        public AccountServiceTest()
        {
            context = ContextGenerator.GetContext();
            service = new AccountService(context, Mapper);
        }

        [Theory]
        [AutoEntityData]
        public async Task CreateAccountAsync_WhenAccountIsValid_AddsToDb(CreateAccountDto account)
        {
            //Arrange
            var contact = new Contact { Email = account.ContactEmail, FirstName = "test", LastName = "test" };
            context.Contacts.Add(contact);
            context.SaveChanges();
            // Act
            await service.CreateAccountAsync(account);
            var result = await context.Accounts.FindAsync(account.Name);

            // Assert
            result.Should().NotBeNull();
        }

        [Theory]
        [AutoEntityData]
        public async Task GetAccountAsync_WhenAccountExists_ReturnsAccount(string name,CreateAccountDto account)
        {
            //Arrange
            account.Name = name;
            var contact = new Contact { Email = account.ContactEmail, FirstName = "test", LastName = "test" };
            context.Contacts.Add(contact);
            context.SaveChanges();
            await service.CreateAccountAsync(account);

            // Act
            var result = await service.GetAccountAsync(account.Name);

            // Assert
            result!.Name.Should().BeEquivalentTo(account.Name);
        }

    }
}
