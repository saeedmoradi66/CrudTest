using AutoMapper;
using Mc2.CrudTest.Presentation.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project1.Application.Common.Dtos.Customers;
using Project1.Application.Common.Interfaces.Repository;
using Project1.Domain.Entities;
using Project1.Domain.Events;
using Project1.Domain.ValueObjects;

namespace Project1.Application.Features.Customers.Commands.CustomerCreate;

public class CustomerCreateCommand : IRequest<Response<Customer>>
{
    public CustomerCreateViewModel CustomerViewModel { get; set; }

}

public class CustomerCreateCommandHandler : BaseRequestHandler<CustomerCreateCommand, Response<Customer>>
{
    public CustomerCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override async Task<Response<Customer>> HandleRequestAsync(CustomerCreateCommand input, CancellationToken cancellationToken)
    {

        var customer = Customer.Create(
            input.CustomerViewModel.FirstName,
            input.CustomerViewModel.LastName,
            input.CustomerViewModel.DateOfBirth,
            input.CustomerViewModel.PhoneNumber,
            input.CustomerViewModel.Email,
            input.CustomerViewModel.BankAccountNumber);
        if (customer.Succeeded)
        {
            var entity =  _unitOfWork.CustomersRepository.GetAll;

            var customerExists= await entity
                .Where(s =>  s.FirstName == customer.Data.FirstName && s.LastName == customer.Data.LastName && s.DateOfBirth == customer.Data.DateOfBirth)
                .FirstOrDefaultAsync();
            if (customerExists != null)
                return new Response<Customer>(null, new List<string> { "user is exists" });

            var emailExists = await entity
                .Where(s =>  s.Email == customer.Data.Email)
                .FirstOrDefaultAsync();
            if (emailExists != null)
                return new Response<Customer>(null, new List<string> { "email  is exists" });


            _unitOfWork.CustomersRepository.Insert(customer.Data);
            customer.Data.AddDomainEvent(new CustomerCreatedEvent(customer.Data));
            await _unitOfWork.Commit();
        }
        return customer;
    }
}
