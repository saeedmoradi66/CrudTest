using FluentAssertions;
using Mc2.CrudTest.Presentation.Shared;
using NUnit.Framework;
using Project1.Application.Features.Customers.Commands.CustomerCreate;
using Project1.Application.Features.Customers.Queries;
using Project1.Domain.Entities;
using static Mc2.CrudTest.AcceptanceTests.Testing;
namespace Mc2.CrudTest.AcceptanceTests.Customers.Queries;
public class GetCustomerTests : BaseTestFixture
{


    [Test]
    public async Task ShouldReturnAllCustomers()
    {
        Random rnd = new Random();
        await SendAsync(new CustomerCreateCommand
        {
            CustomerViewModel = new CustomerCreateViewModel
            {
                FirstName = "saeed"+rnd.Next().ToString(),
                LastName = "moradi",
                PhoneNumber = "09124704964",
                Email = $"saeed.moradi{rnd.Next().ToString()}@gmail.com",
                BankAccountNumber = "IR1234567890123456789012",
                DateOfBirth = "1987/03/29"

            }
        });

        var query = new CustomerGetAllQuery();

        var result = await SendAsync(query);
        result.Data.Should().NotBeNull();
        result.Data.Should().HaveCount(1);
        result.Data.First().LastName.Should().Be("moradi");
    }


}
