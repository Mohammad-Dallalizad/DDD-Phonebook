using ApplicationCore.Enums;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.ContacAggregate;

public class Contact : IBaseEntity, IAggregateRoot
{
    private Contact()
    {
        //required by ef
    }

    public Contact(string? firstName, string? lastName, string? companyName, string? email, DateTime birthdate, Address address, List<Phone> phones)
    {
        FirstName = firstName;
        LastName = lastName;
        CompanyName = companyName;
        Email = email;
        Birthdate = birthdate;
        Address = address;
        _phones = phones;
    }

    public int Id { get; set; }

    public string? FirstName { get; private set; } 

    public string? LastName { get; private set; } 

    public string? CompanyName { get; private set; } 

    public string? Email { get; private set; } 

    public DateTime Birthdate { get; private set; }

    public Address Address { get; private set; }


    private readonly List<Phone> _phones = new();
    public IReadOnlyCollection<Phone> Phones => _phones.AsReadOnly();


    private void RemovePhones()
    {
        _phones.RemoveAll(ph => ph.ContactId == Id);
    }

    public Contact Update(string? firstName, string? lastName, string? companyName, string? email, DateTime birthdate, Address address, List<Phone> phones, CancellationToken cancellationToken)
    {
        FirstName = firstName;
        LastName = lastName; 
        CompanyName = companyName;
        Email = email;
        Birthdate = birthdate;
        Address = address;
        RemovePhones();
        _phones.AddRange(phones);

        return this;
    }
}
