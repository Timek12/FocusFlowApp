using System.Linq.Expressions;

namespace FocusFlow.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, bool tracked = false);
        T? Get(Expression<Func<T, bool>> filter, bool tracked = false);
        void Add(T item);
        void Remove(T item);
    }
}
