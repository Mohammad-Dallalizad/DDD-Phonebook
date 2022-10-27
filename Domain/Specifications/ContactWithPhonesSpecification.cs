using ApplicationCore.Entities.ContacAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications;

public class ContactWithPhonesSpecification : BaseSpecification<Contact>
{
    public ContactWithPhonesSpecification() : base()
    {
        AddInclude(p => p.Phones);
    }

    public ContactWithPhonesSpecification(int id) : base(p => p.Id == id)
    {
        AddInclude(p => p.Phones);
    }
}
