using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Test.BusinessLogic.Dto.IncidentDtos;
using Test.BusinessLogic.Services.Interfaces;
using Test.UnitTest.Base;
using Test.WebApi.Controllers;
using Xunit;

namespace Test.UnitTest.Controllers
{
    public class IncidentControllerTest : Base.Base
    {
        private readonly Mock<IIncidentService> incidentService;
        private readonly IncidentController incidentController;

        public IncidentControllerTest()
        {
            incidentService = new Mock<IIncidentService>();
            incidentController = new IncidentController(incidentService.Object);
        }
        [Theory]
        [AutoEntityData]
        public async Task GetIncident_WhenIncidentExists_ReturnsOkObjectResult(IncidentDto incident)
        {
            // Arrange
            incidentService.Setup(service => service.GetIncidentAsync(incident.Name)).ReturnsAsync(incident);

            // Act
            var result = await incidentController.GetIncident(incident.Name);

            // Assert
            using (new AssertionScope())
            {
                result.Should().BeOfType<OkObjectResult>();
                (result as ObjectResult)?.Value.Should().Be(incident);
            }
        }
        [Theory]
        [AutoEntityData]
        public async Task GetIncident_WhenIncidentDoesNotExist_ReturnsNotFoundResult(IncidentDto incident)
        {
            // Arrange
            incidentService.Setup(service => service.GetIncidentAsync(incident.Name)).ReturnsAsync((IncidentDto?)null);

            // Act
            var result = await incidentController.GetIncident(incident.Name);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }      

        [Theory]
        [AutoEntityData]
        public async Task CreateIncident_WhenAccountAndContactExist(CreateIncidentDto incidentDto)
        {
            // Arrange       

            // Act
            var result = await incidentController.CreateIncident(incidentDto);

            // Assert
            incidentService.Verify(service => service.CreateIncidentAsync(incidentDto));

        }
        [Theory]
        [AutoEntityData]
        public async Task CreateIncident_WhenAccountDoesNotExist_ReturnsNotFoundResult(CreateIncidentDto incidentDto)
        {
            // Arrange       
            incidentService.Setup(x => x.CreateIncidentAsync(incidentDto)).Throws<NullReferenceException>();

            // Act
            var result = await incidentController.CreateIncident(incidentDto);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
        [Theory]
        [AutoEntityData]
        public async Task CreateIncident_WhenContactIsAlreadyLinked_ReturnsBadRequest(CreateIncidentDto incidentDto)
        {
            // Arrange       
            incidentService.Setup(x => x.CreateIncidentAsync(incidentDto)).Throws<InvalidOperationException>();

            // Act
            var result = await incidentController.CreateIncident(incidentDto);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }
    }
}
