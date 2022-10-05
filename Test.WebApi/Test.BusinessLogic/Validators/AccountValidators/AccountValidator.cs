using FluentValidation;
using Test.BusinessLogic.Dto.AccountDtos;

namespace Test.BusinessLogic.Validators.AccountValidators
{
    public class AccountValidator : AbstractValidator<CreateAccountDto>
    {
        public AccountValidator()
        {
            RuleFor(x => x.ContactEmail).NotEmpty().EmailAddress();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
