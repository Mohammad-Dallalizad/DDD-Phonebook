using ApplicationCore.Entities.ContacAggregate;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services;

public class ContactService : IContactService
{
    private readonly IRepository<Contact> _contactRepository;

    public ContactService(IRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public async Task CreateContactAsync(string? firstName, string? lastName, string? companyName, string? email, DateTime birthdate, Address address, List<Phone> phones, CancellationToken cancellationToken)
    {
        var contact = new Contact(firstName, lastName, companyName, email, birthdate, address, phones);

        await _contactRepository.AddAsync(contact, cancellationToken);
    }

    public async Task DeleteContactAsync(int contactId, CancellationToken cancellationToken)
    {
        await _contactRepository.RemoveAsync(contactId, cancellationToken);
    }

    public async Task<IList<Contact>> GetAllContactsAsync(CancellationToken cancellationToken)
    {
        var contactSpec = new ContactWithPhonesSpecification();
        return await _contactRepository.GetAllAsync(contactSpec, cancellationToken);
    }

    public async Task<Contact> GetContactByNameAsync(string name, CancellationToken cancellationToken)
    {
        var contactSpec = new ContactFilterSpecification(name);
        return await _contactRepository.GetBySpecAsync(contactSpec, cancellationToken);
    }

    public async Task UpdateContactAsync(int contactId, string? firstName, string? lastName, string? companyName, string? email, DateTime birthdate, Address address, List<Phone> phones, CancellationToken cancellationToken)
    {
        var contactSpec = new ContactWithPhonesSpecification(contactId);
        var oldcontact = await _contactRepository.GetBySpecAsync(contactSpec, cancellationToken);

        if (oldcontact is null)
        {
            throw new NotFoundException();
        }

        oldcontact.Update(firstName, lastName, companyName, email, birthdate, address, phones, cancellationToken);

        await _contactRepository.UpdateAsync(oldcontact, cancellationToken);
    }


}
