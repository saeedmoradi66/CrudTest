using Project1.Domain.Entities;

namespace Project1.Application.Common.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomersRepository { get; }
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
        Task Commit();
    }
}
