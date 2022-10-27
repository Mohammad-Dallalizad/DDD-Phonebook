using DDD_Phonebook.Dtos;

namespace UnitTest.DtoValidations.Address;

public class Arrangement
{
    public AddressDto ValidAddressDto => new()
    {
        Country = "Iran",
        City = "Tehran",
        Street = "Farahzadi",
        PostalCode = "1467800321"
    };
}
