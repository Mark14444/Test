using AutoMapper;
using Test.BusinessLogic.Dto.IncidentDtos;
using Test.Domain.Entities;

namespace Test.BusinessLogic.Profiles
{
    public class IncidentProfile:Profile
    {
        public IncidentProfile()
        {
            CreateMap<Incident, CreateIncidentDto>().ReverseMap();
            CreateMap<Incident, IncidentDto>();
            CreateMap<Incident, IncidentDto>().ReverseMap();
        }
    }
}
