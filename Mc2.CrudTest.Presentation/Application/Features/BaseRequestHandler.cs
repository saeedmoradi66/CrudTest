using AutoMapper;
using MediatR;
using Project1.Application.Common.Interfaces.Repository;

namespace Project1.Application.Features
{
    public abstract class BaseRequestHandler<TInput, TOutput> : IRequestHandler<TInput, TOutput> where TInput : IRequest<TOutput>
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;
        public BaseRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public BaseRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : this(unitOfWork)
        {
            _mapper = mapper;
        }
        public async Task<TOutput> Handle(TInput request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        protected abstract Task<TOutput> HandleRequestAsync(TInput input, CancellationToken cancellationToken);
    }
}