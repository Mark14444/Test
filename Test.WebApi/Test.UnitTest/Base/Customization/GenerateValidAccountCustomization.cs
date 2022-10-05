using AutoFixture;
using System.Net.Mail;
using Test.BusinessLogic.Dto.AccountDtos;
using Test.BusinessLogic.Dto.ContactDtos;

namespace Test.UnitTest.Base.Customization
{
    public class GenerateValidAccountCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            //fixture.Customize<CreateIncidentDto>(composer =>
            //composer
            //.With(x =>
            //x.Email,
            //fixture.Create<MailAddress>().ToString())
            //.With(x =>
            //x.AccountName,
            //fixture.Create<string>())
            //.With(x =>
            //x.FirstName,
            //fixture.Create<string>())
            //.With(x =>
            //x.LastName,
            //fixture.Create<string>())
            //.With(x =>
            //x.Description,
            //fixture.Create<string>()
            //));

            fixture.Customize<AccountDto>(composer =>
            composer
            .With(x =>
            x.Name,
            fixture.Create<MailAddress>().ToString())
            .Without(x =>
            x.Contacts)
            );

            fixture.Customize<LinkAccountDto>(composer =>
            composer
            .With(x =>
            x.IncidentName,
            fixture.Create<string>())
            .With(x =>
            x.AccountName,
            fixture.Create<string>())
            );

            fixture.Customize<CreateAccountDto>(composer =>
            composer
            .With(x =>
            x.IncidentName,
            fixture.Create<string>())
            .With(x =>
            x.Name,
            fixture.Create<string>())
            .With(x =>
            x.ContactEmail,
            fixture.Create<MailAddress>().ToString())
            );
        }
    }
}
