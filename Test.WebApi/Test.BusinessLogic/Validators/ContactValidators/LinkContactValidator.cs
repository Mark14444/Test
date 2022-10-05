using FluentValidation;
using Test.BusinessLogic.Dto.ContactDtos;

namespace Test.BusinessLogic.Validators.ContactValidators
{
    public class LinkContactValidator : AbstractValidator<LinkContactDto>
    {
        public LinkContactValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.AccountName).NotEmpty();
        }
    }
}
