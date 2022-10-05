using AutoMapper;
using Test.BusinessLogic.Dto.AccountDtos;
using Test.Domain.Entities;

namespace Test.BusinessLogic.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, CreateAccountDto>().ReverseMap();
            CreateMap<Account, AccountDto>();
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}
