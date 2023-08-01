using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project1.Application.Common.Dtos.Customers;
using Project1.Application.Common.Interfaces.Repository;
using Project1.Domain.Common;
using Project1.Domain.Entities;

namespace Project1.Application.Features.Customers.Queries
{

    public class CustomerGetAllQuery : IRequest<Response<List<CustomerViewModel>>>
    {
        
    }

    public class CustomerGetAllQueryHandler : BaseRequestHandler<CustomerGetAllQuery, Response<List<CustomerViewModel>>>
    {
        private readonly ICustomerRepository _CustomerRepository;


        public CustomerGetAllQueryHandler(
            ICustomerRepository CustomerRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            _CustomerRepository = CustomerRepository;
        }

        protected async override Task<Response<List<CustomerViewModel>>> HandleRequestAsync(CustomerGetAllQuery input, CancellationToken cancellationToken)
        {
            var Response = new Response<List<CustomerViewModel>>();
            var data = await _unitOfWork.CustomersRepository.GetAll.AsNoTracking().ToListAsync();
            var viewModel=_mapper.Map<List<CustomerViewModel>>(data);
            return new Response<List<CustomerViewModel>>(viewModel, true);
        }
    }
}
