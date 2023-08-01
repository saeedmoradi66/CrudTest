using AutoMapper;
using Project1.Application.Common.Mappings;
using Project1.Domain.Entities;
using Project1.Domain.ValueObjects;

namespace Project1.Application.Common.Dtos.Customers
{

    public class CustomerViewModel : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerViewModel>()
                 .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName.Value))
                 .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName.Value))
                .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(s => s.DateOfBirth.Value))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber.Value))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email.Value))
                .ForMember(d => d.BankAccountNumber, opt => opt.MapFrom(s => s.BankAccountNumber.Value));

        }
    }
}