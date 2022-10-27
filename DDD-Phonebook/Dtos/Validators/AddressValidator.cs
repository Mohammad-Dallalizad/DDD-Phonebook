using FluentValidation;

namespace DDD_Phonebook.Dtos.Validators;

public class AddressValidator : AbstractValidator<AddressDto>
{
    public AddressValidator()
    {
        RuleFor(p => p.Country).MaximumLength(90);
        
        RuleFor(p => p.City).MaximumLength(100);
        
        RuleFor(p => p.Street).MaximumLength(180);
        
        RuleFor(p => p.PostalCode).MaximumLength(18);
    }
}
