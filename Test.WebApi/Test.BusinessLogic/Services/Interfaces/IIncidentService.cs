using Test.BusinessLogic.Dto.IncidentDtos;

namespace Test.BusinessLogic.Services.Interfaces
{
    public interface IIncidentService
    {
        Task<IncidentDto?> GetIncidentAsync(string name);
        Task CreateIncidentAsync(CreateIncidentDto incident);
    }
}
