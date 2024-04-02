using FocusFlow.Data;
using FocusFlow.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FocusFlow.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public T? Get(Expression<Func<T, bool>> filter, bool tracked = false)
        {
            IQueryable<T> query = dbSet.AsQueryable();

            if(!tracked)
            {
                query = query.AsNoTracking();
            }

            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, bool tracked = false)
        {
            IQueryable<T> query = dbSet.AsQueryable();

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if(filter is not null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public IQueryable<T> GetQuery()
        {
            return dbSet.AsQueryable();
        }
    }
}
