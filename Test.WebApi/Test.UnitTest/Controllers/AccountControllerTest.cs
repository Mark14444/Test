using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Test.BusinessLogic.Dto.AccountDtos;
using Test.BusinessLogic.Services.Interfaces;
using Test.UnitTest.Base;
using Test.WebApi.Controllers;
using Xunit;

namespace Test.UnitTest.Controllers
{
    public class AccountControllerTest : Base.Base
    {
        private readonly Mock<IAccountService> accountService;
        private readonly AccountController accountController;

        public AccountControllerTest()
        {
            accountService = new Mock<IAccountService>();
            accountController = new AccountController(accountService.Object);
        }
        [Theory]
        [AutoEntityData]
        public async Task GetAccount_WhenAccountExists_ReturnsOkObjectResult(AccountDto account)
        {
            // Arrange
            accountService.Setup(service => service.GetAccountAsync(account.Name)).ReturnsAsync(account);

            // Act
            var result = await accountController.GetAccount(account.Name);

            // Assert
            using (new AssertionScope())
            {
                result.Should().BeOfType<OkObjectResult>();
                (result as ObjectResult)?.Value.Should().Be(account);
            }
        }
       
        [Theory]
        [AutoEntityData]
        public async Task LinkAccount_WhenIncidentAndAccountDoNotExist_ReturnsBadRequest(LinkAccountDto accountDto)
        {
            // Arrange  
            accountService.Setup(service => service.LinkAccountWithIncidentAsync(accountDto)).ReturnsAsync(false);

            // Act
            var result = await accountController.LinkAccount(accountDto);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }
        [Theory]
        [AutoEntityData]
        public async Task LinkAccount_WhenIncidentAndAccountExist_ReturnsOkResult(LinkAccountDto accountDto)
        {
            // Arrange  
            accountService.Setup(service => service.LinkAccountWithIncidentAsync(accountDto)).ReturnsAsync(true);

            // Act
            var result = await accountController.LinkAccount(accountDto);

            // Assert
            result.Should().BeOfType<OkResult>();
        }       

        [Theory]
        [AutoEntityData]
        public async Task CreateAccount_WhenAccountIsValid(CreateAccountDto account)
        {
            // Arrange       

            // Act
            var result = await accountController.CreateAccount(account);

            // Assert
            accountService.Verify(service => service.CreateAccountAsync(account));

        }
    }
}