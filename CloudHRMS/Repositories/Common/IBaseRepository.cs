using System.Linq.Expressions;

namespace CloudHRMS.Repositories.Common
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T entity);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetBy(Expression<Func<T,bool >> expression);
        void Update(T entity);
        void Delete(T entity);
    }
}
