using AutoFixture;
using System.Net.Mail;
using Test.BusinessLogic.Dto.ContactDtos;

namespace Test.UnitTest.Base.Customization
{
    public class GenerateValidContactCustomization : ICustomization
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

            fixture.Customize<ContactDto>(composer =>
            composer
            .With(x =>
            x.Email,
            fixture.Create<MailAddress>().ToString())
            .With(x =>
            x.FirstName,
            fixture.Create<string>())
            .With(x =>
            x.LastName,
            fixture.Create<string>())
            );

            fixture.Customize<LinkContactDto>(composer =>
            composer
            .With(x =>
            x.Email,
            fixture.Create<MailAddress>().ToString())
            .With(x =>
            x.AccountName,
            fixture.Create<string>())
            );

            fixture.Customize <ContactWithAccountDto>(composer =>
            composer
            .With(x =>
            x.Email,
            fixture.Create<MailAddress>().ToString())
            .With(x =>
            x.FirstName,
            fixture.Create<string>())
            .With(x =>
            x.LastName,
            fixture.Create<string>())
            .With(x =>
            x.AccountName,
            fixture.Create<string>())
            );
        }
    }
}
