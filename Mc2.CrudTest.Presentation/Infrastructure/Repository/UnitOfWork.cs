using MediatR;
using Project1.Application.Common.Interfaces.Repository;
using Project1.Domain.Entities;
using Project1.Infrastructure.Common;
using Project1.Infrastructure.Persistence;

namespace Project1.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMediator _mediator;

        public UnitOfWork(ApplicationDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;

        }

        public async Task BeginTransaction()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransaction()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }

        public async Task Commit()
        {

            await _mediator.DispatchDomainEvents(_dbContext);
            await _dbContext.SaveChangesAsync();
        }

        private bool _disposed = false;
        public ICustomerRepository CustomersRepository => new CustomerRepository(_dbContext);
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
