using AutoMapper;
using MediatR;
using Project1.Application.Common.Dtos.Customers;
using Project1.Application.Common.Interfaces.Repository;
using Project1.Domain.Common;
using Project1.Domain.Entities;

namespace Project1.Application.Features.Customers.Commands.CustomerDelete;

public class CustomerDeleteCommand : IRequest<Response<CustomerViewModel>>
{
    public int Id { get; set; }

}

public class CustomerDeleteCommandHandler : BaseRequestHandler<CustomerDeleteCommand, Response<CustomerViewModel>>
{
    public CustomerDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override async Task<Response<CustomerViewModel>> HandleRequestAsync(CustomerDeleteCommand input, CancellationToken cancellationToken)
    {
        
        var customer=await _unitOfWork.CustomersRepository.GetById(input.Id);
        _unitOfWork.CustomersRepository.Delete(customer);
        await _unitOfWork.Commit();
        return new Response<CustomerViewModel>();
    }
}
