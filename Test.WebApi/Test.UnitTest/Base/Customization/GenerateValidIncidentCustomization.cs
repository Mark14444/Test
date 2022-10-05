using AutoFixture;
using System.Net.Mail;
using Test.BusinessLogic.Dto.ContactDtos;
using Test.BusinessLogic.Dto.IncidentDtos;

namespace Test.UnitTest.Base.Customization
{
    public class GenerateValidIncidentCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<CreateIncidentDto>(composer =>
            composer
            .With(x =>
            x.Email,
            fixture.Create<MailAddress>().ToString())
            .With(x =>
            x.AccountName,
            fixture.Create<string>())
            .With(x =>
            x.FirstName,
            fixture.Create<string>())
            .With(x =>
            x.LastName,
            fixture.Create<string>())
            .With(x =>
            x.Description,
            fixture.Create<string>()
            ));

            fixture.Customize<IncidentDto>(composer =>
            composer
            .With(x =>
            x.Name,
            fixture.Create<string>())
            .With(x =>
            x.Description,
            fixture.Create<string>()
            ));
        }
    }
}
