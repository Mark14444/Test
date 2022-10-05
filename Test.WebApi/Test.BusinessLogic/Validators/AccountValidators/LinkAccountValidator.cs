using FluentValidation;
using Test.BusinessLogic.Dto.AccountDtos;

namespace Test.BusinessLogic.Validators.AccountValidators
{
    public class LinkAccountValidator : AbstractValidator<LinkAccountDto>
    {
        public LinkAccountValidator()
        {
            RuleFor(x => x.IncidentName).NotEmpty();
            RuleFor(x => x.AccountName).NotEmpty();
        }
    }
}
