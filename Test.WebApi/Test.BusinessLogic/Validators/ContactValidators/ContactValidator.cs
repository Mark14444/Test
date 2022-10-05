using FluentValidation;
using Test.BusinessLogic.Dto.ContactDtos;

namespace Test.BusinessLogic.Validators.ContactValidators
{
    public class ContactValidator:AbstractValidator<ContactDto>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
