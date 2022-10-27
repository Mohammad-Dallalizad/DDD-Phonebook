using DDD_Phonebook.Dtos;
using DDD_Phonebook.Dtos.Validators;
using FluentAssertions;

namespace UnitTest.DtoValidations.Contact;


public class ValidContactCreateOrUpdateDto : TheoryData<ContactCreateOrUpdateDto>
{
    public ValidContactCreateOrUpdateDto()
    {
        var validModel = new Arrangement().ValidContactCreateOrUpdateDto;
        Add(validModel);
    }
}


public class NotValidContactCreateOrUpdateDto : TheoryData<ContactCreateOrUpdateDto>
{
    public NotValidContactCreateOrUpdateDto()
    {
        var validModel = new Arrangement().ValidContactCreateOrUpdateDto;

        // Firstname
        Add(validModel with { Firstname = new string('0', 51) });

        // Lastname
        Add(validModel with { Lastname = new string('0', 51) });

        // Companyname
        Add(validModel with { Companyname = new string('0', 51) });

        // Email
        Add(validModel with { Email = new string('0', 310) });
        Add(validModel with { Email = new string('a', 30) });
    }
}
public class PhoneViewModelValidationProcess
{
    [Theory]
    [ClassData(typeof(ValidContactCreateOrUpdateDto))]
    public void ValidContactCreateOrUpdateDto(ContactCreateOrUpdateDto dto)
    {
        //Arrange
        var validator = new ContactValidator();

        //Act & Assert
        validator.Validate(dto).IsValid.Should().BeTrue();
    }

    [Theory]
    [ClassData(typeof(NotValidContactCreateOrUpdateDto))]
    public void NotValidContactCreateOrUpdateDto(ContactCreateOrUpdateDto dto)
    {
        //Arrange
        var validator = new ContactValidator();

        //Act & Assert
        validator.Validate(dto).IsValid.Should().BeFalse();
    }
}
