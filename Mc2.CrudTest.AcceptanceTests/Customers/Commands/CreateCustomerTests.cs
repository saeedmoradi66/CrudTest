using FluentAssertions;
using Mc2.CrudTest.AcceptanceTests;
using Mc2.CrudTest.Presentation.Shared;
using NUnit.Framework;
using Project1.Application.Features.Customers.Commands.CustomerCreate;
using Project1.Domain.Entities;
using Project1.Domain.Exceptions;
using static Mc2.CrudTest.AcceptanceTests.Testing;

namespace Mc2.CrudTest.AcceptanceTests.Customers.Commands;
public class CreateCustomerTests : BaseTestFixture
{
   
    [Test]
    public async Task ShouldRequireUniqueCustomer()
    {
        Random rnd = new Random();
        await SendAsync(new CustomerCreateCommand
        {
            CustomerViewModel = new CustomerCreateViewModel
            {
                FirstName = "saeed",
                LastName = "moradi",
                PhoneNumber = "09124704968",
                Email = $"saeed.moradi{rnd.Next().ToString()}@gmail.com",
                BankAccountNumber = "IR1234567890123456789012",
                DateOfBirth = "1987/03/29"

            }
        });
       
        var command = new CustomerCreateCommand
        {
            CustomerViewModel = new CustomerCreateViewModel
            {
                FirstName = "saeed",
                LastName = "moradi",
                PhoneNumber = "09124704968",
                Email = $"saeed.moradi{rnd.Next().ToString()}@gmail.com",
                BankAccountNumber = "IR1234567890123456789012",
                DateOfBirth = "1987/03/29"

            }
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().NotThrowAsync<ValidationException>();

    }

    [Test]
    public async Task ShouldRequireUniqueEmail()
    {
        Random rnd = new Random();
        await SendAsync(new CustomerCreateCommand
        {
            CustomerViewModel = new CustomerCreateViewModel
            {
                FirstName = "saeed" + rnd.Next().ToString(),
                LastName = "moradi",
                PhoneNumber = "09124704968",
                Email = "saeed.moradi3@gmail.com",
                BankAccountNumber = "IR1234567890123456789012",
                DateOfBirth = "1987/03/29"

            }
        });
        
        var command = new CustomerCreateCommand
        {
            CustomerViewModel = new CustomerCreateViewModel
            {
                FirstName = "saeed" + rnd.Next().ToString(),
                LastName = "moradi",
                PhoneNumber = "09124704968",
                Email = $"saeed.moradi3@gmail.com",
                BankAccountNumber = "IR1234567890123456789012",
                DateOfBirth = "1987/03/29"

            }
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().NotThrowAsync<ValidationException>();

    }

    [Test]
    public async Task ShouldCreateCustomer()
    {
        Random rnd = new Random();
        var command = new CustomerCreateCommand
        {
            CustomerViewModel = new CustomerCreateViewModel
            {
                FirstName = "saeed" + rnd.Next().ToString(),
                LastName = "moradi",
                PhoneNumber = "09124704960",
                Email = $"saeed.moradi{rnd.Next().ToString()}@gmail.com",
                BankAccountNumber = "IR1234567890123456789012",
                DateOfBirth = "1987/03/29"

            }
        };

        var response = await SendAsync(command);

        var result = await FindAsync<Customer>(response.Data.Id);

        result.Should().NotBeNull();
        result!.FirstName.Value.Should().Be(command.CustomerViewModel.FirstName);


    }
}
