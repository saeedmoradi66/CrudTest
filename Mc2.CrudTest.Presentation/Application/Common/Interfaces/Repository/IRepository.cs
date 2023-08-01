using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Application.Common.Interfaces.Repository
{
    public interface IRepository<T>
    {
        Task<T?> GetById(object ID);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll { get; }

    }
}
