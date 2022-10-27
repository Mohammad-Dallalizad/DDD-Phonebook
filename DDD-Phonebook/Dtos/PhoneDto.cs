using ApplicationCore.Enums;

namespace DDD_Phonebook.Dtos;

public record class PhoneDto
{
    public string PhoneNumber { get; init; } = null!;

    public string Lable { get; init; }
}
