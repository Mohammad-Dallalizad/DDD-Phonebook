using ApplicationCore.Enums;

namespace DDD_Phonebook.Dtos;

public record class PhoneCreateOrUpdateDto
{
    public string PhoneNumber { get; init; } = null!;

    public PhoneLable Lable { get; init; }
}
