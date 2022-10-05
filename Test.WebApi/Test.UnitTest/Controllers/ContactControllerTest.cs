using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Test.BusinessLogic.Dto.ContactDtos;
using Test.BusinessLogic.Services.Interfaces;
using Test.UnitTest.Base;
using Test.WebApi.Controllers;
using Xunit;

namespace Test.UnitTest.Controllers
{
    public class ContactControllerTest : Base.Base
    {
        private readonly Mock<IContactService> contactService;
        private readonly ContactController contactController;

        public ContactControllerTest()
        {
            contactService = new Mock<IContactService>();
            contactController = new ContactController(contactService.Object);
        }
        [Theory]
        [AutoEntityData]
        public async Task GetContact_WhenContactExists_ReturnsOkObjectResult(ContactWithAccountDto contact)
        {
            // Arrange
            contactService.Setup(service => service.GetContactAsync(contact.Email)).ReturnsAsync(contact);

            // Act
            var result = await contactController.GetContact(contact.Email);

            // Assert
            using (new AssertionScope())
            {
                result.Should().BeOfType<OkObjectResult>();
                (result as ObjectResult)?.Value.Should().Be(contact);
            }
        }
        [Theory]
        [AutoEntityData]
        public async Task UpdateContact_WhenContactExists_ReturnsOkResult(ContactWithAccountDto contact)
        {
            // Arrange       
            contactService.Setup(service => service.UpdateContactAsync(contact)).ReturnsAsync(true);

            // Act
            var result = await contactController.UpdateContact(contact);

            // Assert
            result.Should().BeOfType<OkResult>();

        }
        [Theory]
        [AutoEntityData]
        public async Task LinkContact_WhenContactAndAccountDoNotExist_ReturnsBadRequest(LinkContactDto contactDto)
        {
            // Arrange  
            contactService.Setup(service => service.LinkAccountWithContactAsync(contactDto)).ReturnsAsync(false);

            // Act
            var result = await contactController.LinkContact(contactDto);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }
        [Theory]
        [AutoEntityData]
        public async Task LinkContact_WhenContactAndAccountExist_ReturnsOkResult(LinkContactDto contactDto)
        {
            // Arrange  
            contactService.Setup(service => service.LinkAccountWithContactAsync(contactDto)).ReturnsAsync(true);

            // Act
            var result = await contactController.LinkContact(contactDto);

            // Assert
            result.Should().BeOfType<OkResult>();
        }
        [Theory]
        [AutoEntityData]
        public async Task UpdateContact_WhenContactDoesNotExist_ReturnsBadRequest(ContactWithAccountDto contact)
        {
            // Arrange       
            contactService.Setup(service => service.UpdateContactAsync(contact)).ReturnsAsync(false);

            // Act
            var result = await contactController.UpdateContact(contact);

            // Assert
            result.Should().BeOfType<BadRequestResult>();

        }

        [Theory]
        [AutoEntityData]
        public async Task CreateContact_WhenContactIsValid(ContactDto contact)
        {
            // Arrange       

            // Act
            var result = await contactController.CreateContact(contact);

            // Assert
            contactService.Verify(service => service.CreateContactAsync(contact));

        }
    }
}
