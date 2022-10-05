using FluentValidation;
using Test.BusinessLogic.Dto.IncidentDtos;

namespace Test.BusinessLogic.Validators.IncidentValidators
{
    public class IncidentValidator:AbstractValidator<CreateIncidentDto>
    {
        public IncidentValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => new { x.AccountName, x.FirstName, x.LastName}).NotEmpty();
        }
    }
}
