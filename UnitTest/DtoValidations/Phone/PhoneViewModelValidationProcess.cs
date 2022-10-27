using ApplicationCore.Enums;
using DDD_Phonebook.Dtos;
using DDD_Phonebook.Dtos.Validators;
using FluentAssertions;

namespace UnitTest.DtoValidations.Phone;


public class ValidPhoneCreateOrUpdateDto : TheoryData<PhoneCreateOrUpdateDto>
{
    public ValidPhoneCreateOrUpdateDto()
    {
        var validModel = new Arrangement().ValidPhoneCreateOrUpdateDto;
        Add(validModel);
    }
}


public class NotValidPhoneCreateOrUpdateDto : TheoryData<PhoneCreateOrUpdateDto>
{
    public NotValidPhoneCreateOrUpdateDto()
    {
        var validModel = new Arrangement().ValidPhoneCreateOrUpdateDto;

        // PhoneNumber
        Add(validModel with { PhoneNumber = new string('0', 16) });
        Add(validModel with { PhoneNumber = new string('a', 10) });

        // Lable
        Add(validModel with { Lable = (PhoneLable)8 });

    }
}
public class PhoneViewModelValidationProcess
{
    [Theory]
    [ClassData(typeof(ValidPhoneCreateOrUpdateDto))]
    public void ValidPhoneCreateOrUpdateDto(PhoneCreateOrUpdateDto dto)
    {
        //Arrange
        var validator = new PhoneValidator();

        //Act & Assert
        validator.Validate(dto).IsValid.Should().BeTrue();
    }

    [Theory]
    [ClassData(typeof(NotValidPhoneCreateOrUpdateDto))]
    public void NotValidPhoneCreateOrUpdateDto(PhoneCreateOrUpdateDto dto)
    {
        //Arrange
        var validator = new PhoneValidator();

        //Act & Assert
        validator.Validate(dto).IsValid.Should().BeFalse();
    }
}
