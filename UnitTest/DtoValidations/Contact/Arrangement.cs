using DDD_Phonebook.Dtos;

namespace UnitTest.DtoValidations.Contact;

public class Arrangement
{
    public ContactCreateOrUpdateDto ValidContactCreateOrUpdateDto => new()
    {
        Firstname = "Iran",
        Lastname = "Tehran",
        Companyname = "Farahzadi",
        Email = "mohammad@gmail.com",
        Birthdate = DateTime.UtcNow,
        Address = new AddressDto() {
            Country = "Iran",
            City = "Tehran",
            Street = "Farahzadi",
            PostalCode = "1467800321"
        },
        Phones = new List<PhoneCreateOrUpdateDto>() { 
            new PhoneCreateOrUpdateDto() { PhoneNumber = "09121112233",Lable = ApplicationCore.Enums.PhoneLable.Mobile}, 
            new PhoneCreateOrUpdateDto() { PhoneNumber = "02188975123",Lable = ApplicationCore.Enums.PhoneLable.Home}, 
            new PhoneCreateOrUpdateDto() { PhoneNumber = "02144556822",Lable = ApplicationCore.Enums.PhoneLable.School}, 
            new PhoneCreateOrUpdateDto() { PhoneNumber = "026311998534",Lable = ApplicationCore.Enums.PhoneLable.WorkFax}, 
        },
    };
}
