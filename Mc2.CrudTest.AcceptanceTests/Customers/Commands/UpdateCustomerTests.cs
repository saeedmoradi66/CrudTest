using Azure;
using FluentAssertions;
using Mc2.CrudTest.AcceptanceTests;
using Mc2.CrudTest.Presentation.Shared;
using NUnit.Framework;
using Project1.Application.Features.Customers.Commands.CustomerCreate;
using Project1.Application.Features.Customers.Commands.CustomerUpdate;
using Project1.Domain.Entities;
using Project1.Domain.Exceptions;
using static Mc2.CrudTest.AcceptanceTests.Testing;

namespace Mc2.CrudTest.AcceptanceTests.Customers.Commands;
public class UpdateCustomerTests : BaseTestFixture
{
    

    [Test]
    public async Task ShouldUpdateCustomer()
    {
        Random rnd = new Random();
        var response = await SendAsync(new CustomerCreateCommand
        {
            CustomerViewModel = new CustomerCreateViewModel
            {
                FirstName = "saeed" + rnd.Next().ToString(),
                LastName = "moradi",
                PhoneNumber = "09124704962",
                Email = $"saeed.moradi{rnd.Next().ToString()}@gmail.com",
                BankAccountNumber = "IR1234567890123456789012",
                DateOfBirth = "1987/03/29"

            }
        });

        var command = new CustomerUpdateCommand
        {
            CustomerViewModel = new CustomerUpdateViewModel
            {
                Id = response.Data.Id,
                FirstName = "saeed" + rnd.Next().ToString(),
                LastName = "moradi",
                PhoneNumber = "09124704963",
                Email = $"saeed.moradi{rnd.Next().ToString()}@gmail.com",
                BankAccountNumber = "IR1234567890123456789012",
                DateOfBirth = "1987/03/29"

            }
        };

        await SendAsync(command);

        var list = await FindAsync<Customer>(response.Data.Id);

        list.Should().NotBeNull();
        list!.BankAccountNumber.Value.Should().Be(command.CustomerViewModel.BankAccountNumber);

    }
}
