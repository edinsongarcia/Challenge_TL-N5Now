using System.Linq.Expressions;

namespace ChallengeN5Now.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> Get(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        bool HasEmployeePermission(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
