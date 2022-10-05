using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;

namespace IS.Web.Contractor
{
    public interface IBaseRepository<T> where T : class
    {
        DatabaseFacade Database { get; }
        Task<IEnumerable<T>> GetAll();
        Task<int> Count(Expression<Func<T, bool>> condition);
        Task<int> Count();
        Task<T> Last<T1>(Expression<Func<T, T1>> sort);
        Task<T> Last<T1>(Expression<Func<T, bool>> condition, Expression<Func<T, T1>> sort);
        Task<T> Find(object id);
        Task Insert(T model);
        Task Update(object id, object entities);
    }
}