using FluentValidation;

namespace DDD_Phonebook.Dtos.Validators;

public class ContactValidator : AbstractValidator<ContactCreateOrUpdateDto>
{
    public ContactValidator()
    {
        RuleFor(p => p.Firstname).MaximumLength(50);

        RuleFor(p => p.Lastname).MaximumLength(50);

        RuleFor(p => p.Companyname).MaximumLength(50);

        RuleFor(p => p.Email).EmailAddress().MaximumLength(300);

        RuleFor(p => p.Address).SetValidator(new AddressValidator());

        RuleForEach(p => p.Phones).SetValidator(new PhoneValidator());
    }
}
