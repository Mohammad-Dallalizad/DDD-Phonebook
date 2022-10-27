using ApplicationCore.Entities.ContacAggregate;

namespace ApplicationCore.Interfaces;

public interface IContactService
{
    Task CreateContactAsync(string? firstName, string? lastName, string? companyName, string? email, DateTime birthdate, Address address, List<Phone> phones, CancellationToken cancellationToken);

    Task DeleteContactAsync(int contactId, CancellationToken cancellationToken);

    Task<IList<Contact>> GetAllContactsAsync(CancellationToken cancellationToken);

    Task UpdateContactAsync(int contactId, string? firstName, string? lastName, string? companyName, string? email, DateTime birthdate, Address address, List<Phone> phones, CancellationToken cancellationToken);

    Task<Contact> GetContactByNameAsync(string name, CancellationToken cancellationToken);
}
