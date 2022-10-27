namespace ApplicationCore.Entities.ContacAggregate;

public class Address
{
    private Address() { }

    public Address(string country, string city, string street, string postalCode)
    {
        Country = country;
        City = city;
        Street = street;
        PostalCode = postalCode;
    }

    public string? Country { get; private set; } 

    public string? City { get; private set; } 

    public string? Street { get; private set; } 

    public string? PostalCode { get; private set; } 

}

