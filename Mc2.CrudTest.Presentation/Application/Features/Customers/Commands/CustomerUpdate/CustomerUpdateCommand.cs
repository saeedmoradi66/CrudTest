using AutoMapper;
using Mc2.CrudTest.Presentation.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project1.Application.Common.Dtos.Customers;
using Project1.Application.Common.Interfaces.Repository;
using Project1.Domain.Entities;
using Project1.Domain.Events;

namespace Project1.Application.Features.Customers.Commands.CustomerUpdate;

public class CustomerUpdateCommand : IRequest<Response<Customer>>
{
    public CustomerUpdateViewModel CustomerViewModel { get; set; }

}

public class CustomerUpdateCommandHandler : BaseRequestHandler<CustomerUpdateCommand, Response<Customer>>
{
    public CustomerUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override async Task<Response<Customer>> HandleRequestAsync(CustomerUpdateCommand input, CancellationToken cancellationToken)
    {
        var customer = Customer.Update(
            input.CustomerViewModel.Id,
            input.CustomerViewModel.FirstName,
            input.CustomerViewModel.LastName,
            input.CustomerViewModel.DateOfBirth,
            input.CustomerViewModel.PhoneNumber,
            input.CustomerViewModel.Email,
            input.CustomerViewModel.BankAccountNumber);
        if (customer.Succeeded)
        {
            var entity = _unitOfWork.CustomersRepository.GetAll;

            var customerExists=await entity
                .Where(s=>s.Id!=input.CustomerViewModel.Id && s.FirstName== customer.Data.FirstName && s.LastName == customer.Data.LastName && s.DateOfBirth == customer.Data.DateOfBirth)
                .FirstOrDefaultAsync();
           if(customerExists != null)
                return new Response<Customer>(null,new List<string> { "user is exists"});

            var emailExists = await entity
                .Where(s => s.Id != input.CustomerViewModel.Id && s.Email == customer.Data.Email)
                .FirstOrDefaultAsync();
            if (emailExists != null)
                return new Response<Customer>(null, new List<string> { "email is exists" });


            _unitOfWork.CustomersRepository.Update(customer.Data);
            await _unitOfWork.Commit();
        }
        return new Response<Customer>();
    }
}
