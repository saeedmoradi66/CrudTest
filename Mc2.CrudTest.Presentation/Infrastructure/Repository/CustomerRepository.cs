using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Application.Common.Interfaces.Repository;
using Project1.Domain.Entities;
using Project1.Infrastructure.Persistence;

namespace Project1.Infrastructure.Repository;
public class CustomerRepository : EFRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context) : base(context)
    {
    }
}
