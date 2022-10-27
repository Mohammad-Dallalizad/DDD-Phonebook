namespace DDD_Phonebook.Dtos;

public record class ContactDto
{
    public int Id { get; init; }

    public string? Firstname { get; init; }

    public string? Lastname { get; init; } 

    public string? Companyname { get; init; } 

    public string? Email { get; init; } 

    public DateTime Birthdate { get; init; }

    public AddressDto Address { get; init; }

    public IList<PhoneDto> Phones { get; init; }
}
