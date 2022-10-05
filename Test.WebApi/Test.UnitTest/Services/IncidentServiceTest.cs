using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Test.BusinessLogic.Dto.IncidentDtos;
using Test.BusinessLogic.Services.Implementation;
using Test.BusinessLogic.Services.Interfaces;
using Test.Domain.Context;
using Test.Domain.Entities;
using Test.UnitTest.Base;
using Xunit;

namespace Test.UnitTest.Services
{
    public class IncidentServiceTest : Base.Base
    {
        private readonly IIncidentService service;
        private readonly TestContext context;
        public IncidentServiceTest()
        {
            context = ContextGenerator.GetContext();
            service = new IncidentService(context, Mapper);
        }

        [Theory]
        [AutoEntityData]
        public async Task CreateIncidentAsync_WhenAccountIsValid_AddsToDb(CreateIncidentDto incidentDto)
        {
            //Arrange
            var account = new Account { Name = incidentDto.AccountName };
            context.Accounts.Add(account);
            context.SaveChanges();
            // Act
            await service.CreateIncidentAsync(incidentDto);
            var result = context.Incidents.SingleOrDefault(x => x.Description == incidentDto.Description);

            // Assert
            result.Should().NotBeNull();
        }

        [Theory]
        [AutoEntityData]
        public async Task GetIncidentAsync_WhenIncidentExists_ReturnsIncident(CreateIncidentDto incidentDto)
        {
            //Arrange
            var account = new Account { Name = incidentDto.AccountName };
            context.Accounts.Add(account);
            context.SaveChanges();
            await service.CreateIncidentAsync(incidentDto);
            account = context.Accounts.Find(incidentDto.AccountName);

            // Act
            var result = await service.GetIncidentAsync(account!.IncidentName!);

            // Assert
            result!.Name.Should().BeEquivalentTo(account!.IncidentName!);
        }

    }
}

