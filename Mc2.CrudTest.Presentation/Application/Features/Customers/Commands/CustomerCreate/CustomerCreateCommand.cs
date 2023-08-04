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


        _unitOfWork.CustomersRepository.Insert(customer);
        customer.AddDomainEvent(new CustomerCreatedEvent(customer));
        await _unitOfWork.Commit();

        return new Response<Customer>(customer, true);
    }
}
