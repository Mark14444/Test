using Microsoft.AspNetCore.Mvc;
using Test.BusinessLogic.Dto.ContactDtos;
using Test.BusinessLogic.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetContact(string email)
        {
            var contact = await _contactService.GetContactAsync(email);
            if(contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateContact(ContactDto contactDto)
        {
            await _contactService.CreateContactAsync(contactDto);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateContact(ContactWithAccountDto contactDto)
        {
            bool isUpdated = await _contactService.UpdateContactAsync(contactDto);
            return isUpdated ? Ok(): BadRequest();
        }
        [HttpPut("LinkToAccount")]
        public async Task<IActionResult> LinkContact(LinkContactDto linkContact)
        {
            return await _contactService.LinkAccountWithContactAsync(linkContact) ? Ok() : BadRequest();
        }

    }
}
