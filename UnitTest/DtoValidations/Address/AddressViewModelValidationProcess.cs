using DDD_Phonebook.Dtos;
using DDD_Phonebook.Dtos.Validators;
using FluentAssertions;

namespace UnitTest.DtoValidations.Address;


public class ValidAddressDto : TheoryData<AddressDto>
{
    public ValidAddressDto()
    {
        var validModel = new Arrangement().ValidAddressDto;
        Add(validModel);
    }
}


public class NotValidAddressDto : TheoryData<AddressDto>
{
    public NotValidAddressDto()
    {
        var validModel = new Arrangement().ValidAddressDto;

        // Country
        Add(validModel with { Country = new string('0', 91) });

        // City
        Add(validModel with { City = new string('0', 101) });

        // Street
        Add(validModel with { Street = new string('0', 181) });

        //PostalCode
        Add(validModel with { PostalCode = new string('0', 19) });

    }
}
public class PhoneViewModelValidationProcess
{
    [Theory]
    [ClassData(typeof(ValidAddressDto))]
    public void ValidAddressDto(AddressDto dto)
    {
        //Arrange
        var validator = new AddressValidator();

        //Act & Assert
        validator.Validate(dto).IsValid.Should().BeTrue();
    }

    [Theory]
    [ClassData(typeof(NotValidAddressDto))]
    public void NotValidAddressDto(AddressDto dto)
    {
        //Arrange
        var validator = new AddressValidator();

        //Act & Assert
        validator.Validate(dto).IsValid.Should().BeFalse();
    }
}
