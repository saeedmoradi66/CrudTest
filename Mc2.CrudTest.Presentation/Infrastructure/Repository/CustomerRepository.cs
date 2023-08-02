using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project1.Application.Common.Interfaces.Repository;
using Project1.Domain.Entities;
using Project1.Domain.ValueObjects;
using Project1.Infrastructure.Persistence;

namespace Project1.Infrastructure.Repository;
public class CustomerRepository : EFRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context) : base(context)
    {
    }
    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        var result = await GetAll.AnyAsync(s => s.Email.Equals(new Email(email)));
        return !result;
    }
    public async Task<bool> IsCustomerUniqueAsync(string firstName, string lastName, string dateOfBirth)
    {
        var result = await GetAll.AsNoTracking()
            .AnyAsync(s => s.FirstName == new FirstName(firstName) && s.LastName == new LastName(lastName) && s.DateOfBirth == new DateOfBirth(dateOfBirth));
        return !result;
    }
}
