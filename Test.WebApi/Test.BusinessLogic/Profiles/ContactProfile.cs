using AutoMapper;
using Test.BusinessLogic.Dto.ContactDtos;
using Test.BusinessLogic.Dto.IncidentDtos;
using Test.Domain.Entities;

namespace Test.BusinessLogic.Profiles
{
    public class ContactProfile:Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactWithAccountDto>().ReverseMap();
            CreateMap<Contact, CreateIncidentDto>().ReverseMap();
            CreateMap<Contact, ContactDto>();
            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}
