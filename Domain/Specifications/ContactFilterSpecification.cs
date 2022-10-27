using ApplicationCore.Entities.ContacAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications;

public class ContactFilterSpecification : BaseSpecification<Contact>
{
    public ContactFilterSpecification(string name) : base(p => (!string.IsNullOrEmpty(p.FirstName) && p.FirstName.Equals(name)) || (!string.IsNullOrEmpty(p.LastName) && p.LastName.Equals(name)) || (!string.IsNullOrEmpty(p.CompanyName) && p.CompanyName.Equals(name)))
    {
        AddInclude(p => p.Phones);
    }
}
