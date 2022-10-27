using DDD_Phonebook.Dtos;

namespace UnitTest.DtoValidations.Phone;

public class Arrangement
{
    public PhoneCreateOrUpdateDto ValidPhoneCreateOrUpdateDto => new()
    {
        PhoneNumber = "09121112233",
        Lable = ApplicationCore.Enums.PhoneLable.Mobile
    };
}
