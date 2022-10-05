using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Test.BusinessLogic.Profiles;
using Test.BusinessLogic.Services.Implementation;
using Test.BusinessLogic.Services.Interfaces;
using Test.Domain.Context;

namespace Test.BusinessLogic.Extensions
{
    public static class Dependencies
    {
        public static void AddDb(this IServiceCollection services)
        {
            services.AddDbContext<ITestContext,TestContext>();
        }
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IIncidentService, IncidentService>();
        }
        public static void AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<ContactService>());
        }
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(new List<Profile> { new ContactProfile(),new AccountProfile(),new IncidentProfile() });
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
