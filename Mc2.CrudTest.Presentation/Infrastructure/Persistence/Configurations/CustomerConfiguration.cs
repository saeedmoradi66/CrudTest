using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project1.Domain.Entities;
using Project1.Domain.ValueObjects;

namespace Project1.Infrastructure.Persistence.Configurations;
public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.FirstName)
            .HasConversion(c => c.Value, c => new FirstName(c))
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasConversion(c => c.Value, c => new LastName(c))
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.DateOfBirth)
            .HasConversion(c => c.Value, c => new DateOfBirth(c))
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasConversion(c => c.Value, c => new Email(c))
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(c => c.PhoneNumber)
            .HasConversion(c => c.Value, c => new PhoneNumber(c))
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(c => c.BankAccountNumber)
            .HasConversion(c => c.Value, c => new BankAccountNumber(c))
            .HasMaxLength(24)
            .IsRequired();
    }
}
