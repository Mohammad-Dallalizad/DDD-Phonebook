using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.ContacAggregate;

public class Phone : IBaseEntity
{
    private Phone()
    {
        //required by ef
    }

    public Phone(string phoneNumber, PhoneLable lable)
    {
        PhoneNumber = phoneNumber;
        Lable = lable;
    }

    public int Id { get; set; }

    public string PhoneNumber { get; private set; } = null!;

    public PhoneLable Lable { get; private set; }

    public int ContactId { get; private set; }
}
