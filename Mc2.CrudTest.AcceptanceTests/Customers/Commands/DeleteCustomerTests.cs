using FluentAssertions;
using Mc2.CrudTest.AcceptanceTests;
using Mc2.CrudTest.Presentation.Shared;
using NUnit.Framework;
using Project1.Application.Common.Dtos.Customers;
using Project1.Application.Features.Customers.Commands.CustomerCreate;
using Project1.Application.Features.Customers.Commands.CustomerDelete;
using Project1.Domain.Entities;
using Project1.Domain.Exceptions;
using static Mc2.CrudTest.AcceptanceTests.Testing;

namespace Mc2.CrudTest.AcceptanceTests.Customers.Commands;
public class DeleteCustomerTests : BaseTestFixture
{
    

    [Test]
    public async Task ShouldDeleteCustomer()
    {
        Random rnd = new Random();
        var result = await SendAsync(new CustomerCreateCommand
        {
            CustomerViewModel = new CustomerCreateViewModel
            {
                FirstName = "saeed"+rnd.Next().ToString(),
                LastName = "moradi",
                PhoneNumber = "09124704961",
                Email = $"saeed.moradi{rnd.Next().ToString()}@gmail.com",
                BankAccountNumber = "IR1234567890123456789012",
                DateOfBirth = "1987/03/29"

            }
        });

        await SendAsync(new CustomerDeleteCommand { Id = result.Data.Id });

        var response = await FindAsync<Customer>(result.Data.Id);

        response.Should().BeNull();
    }
}
