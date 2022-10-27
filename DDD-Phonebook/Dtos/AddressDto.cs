namespace DDD_Phonebook.Dtos;

public record class AddressDto
{
    public string Country { get; init; } = null!;

    public string City { get; init; } = null!;

    public string Street { get; init; } = null!;

    public string PostalCode { get; init; } = null!;
}
