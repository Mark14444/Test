using Microsoft.AspNetCore.Mvc;
using Test.BusinessLogic.Dto.IncidentDtos;
using Test.BusinessLogic.Services.Interfaces;

namespace Test.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _service;
        public IncidentController(IIncidentService service)
        {
            _service = service;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetIncident(string name)
        {
            var incident = await _service.GetIncidentAsync(name);
            if (incident == null)
            {
                return NotFound();
            }
            return Ok(incident);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateIncident(CreateIncidentDto account)
        {
            try
            {
                await _service.CreateIncidentAsync(account);
            }
            catch(Exception ex)
            {
                if (ex is NullReferenceException)
                    return NotFound();
                else
                    return BadRequest();
            }
            return Ok();
        }
    }
}
