using Project1.Application.Common.Mappings;
using Project1.Domain.Entities;
using Project1.Domain.ValueObjects;

namespace Project1.Application.Common.Dtos.Customers
{
    public class CustomerUpdateViewModel 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }

}