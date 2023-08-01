using Microsoft.EntityFrameworkCore;
using Project1.Application.Common.Interfaces.Repository;
using Project1.Infrastructure.Persistence;

namespace Project1.Infrastructure.Repository
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        #region Fields

        private readonly ApplicationDbContext _context;
        private DbSet<T> _entities;

        #endregion

        #region Constructor

        public EFRepository(ApplicationDbContext context) => _context = context;

        #endregion

        #region Private Properties

        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }

                return _entities;
            }
        }

        #endregion

        #region Implementation of IRepository

        public async Task<T?> GetById(object ID)
        {
            return await Entities.FindAsync(ID);
        }

        public void Insert(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {

            _context.Entry(entity).State = EntityState.Deleted;
        }


        public IQueryable<T> GetAll
        {
            get
            {
                return Entities;
            }
        }

        #endregion

    }
}
