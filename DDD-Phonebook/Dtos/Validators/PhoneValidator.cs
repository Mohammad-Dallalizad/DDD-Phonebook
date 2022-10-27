
using FluentValidation;

namespace DDD_Phonebook.Dtos.Validators;

public class PhoneValidator : AbstractValidator<PhoneCreateOrUpdateDto>
{
    public PhoneValidator()
    {
        RuleFor(p => p.PhoneNumber).MaximumLength(15).Matches(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

        RuleFor(p => p.Lable).IsInEnum();
    }
}
