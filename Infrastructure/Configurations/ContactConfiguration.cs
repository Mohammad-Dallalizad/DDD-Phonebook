using ApplicationCore.Entities.ContacAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        var navigation = builder.Metadata.FindNavigation(nameof(Contact.Phones));
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.OwnsOne(o => o.Address, a =>
        {
            a.WithOwner();

            a.Property(a => a.PostalCode).HasMaxLength(18);

            a.Property(a => a.Street).HasMaxLength(180);

            a.Property(a => a.Country).HasMaxLength(90);

            a.Property(a => a.City).HasMaxLength(100);
        });
        builder.Navigation(x => x.Address).IsRequired();

        builder.Property(p => p.FirstName).HasMaxLength(50);

        builder.Property(p => p.LastName).HasMaxLength(50);

        builder.Property(p => p.CompanyName).HasMaxLength(50);

        builder.Property(p => p.Email).HasMaxLength(300);

        builder.Property(p => p.Birthdate).HasColumnType("date");

    }
}
