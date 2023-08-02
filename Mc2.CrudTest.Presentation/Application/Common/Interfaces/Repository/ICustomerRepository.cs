using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Domain.Entities;

namespace Project1.Application.Common.Interfaces.Repository;
public interface ICustomerRepository : IRepository<Customer>
{
    Task<bool> IsEmailUniqueAsync(string email);
    Task<bool> IsCustomerUniqueAsync(string firstName, string lastName, string dateOfBirth);
}
