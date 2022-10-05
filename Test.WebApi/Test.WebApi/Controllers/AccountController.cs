using Microsoft.AspNetCore.Mvc;
using Test.BusinessLogic.Dto.AccountDtos;
using Test.BusinessLogic.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAccount(string name)
        {
            var account = await _service.GetAccountAsync(name);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAccount(CreateAccountDto account)
        {
            await _service.CreateAccountAsync(account);
            return Ok();
        }

        [HttpPut("LinkToIncident")]
        public async Task<IActionResult> LinkAccount(LinkAccountDto linkAccount)
        {
            return await _service.LinkAccountWithIncidentAsync(linkAccount) ? Ok() : BadRequest();
        }
    }
}
