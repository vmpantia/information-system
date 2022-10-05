using IS.Web.Contractor;
using IS.Web.DataAccess;
using IS.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;

namespace IS.Web.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _table;

        public BaseRepository(ISDbContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public DatabaseFacade Database { get { return _db.Database; } }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<int> Count(Expression<Func<T, bool>> condition)
        {
            return await _table.Where(condition).CountAsync();
        }

        public async Task<int> Count()
        {
            return await _table.CountAsync();
        }

        public async Task<T> Last<T1>(Expression<Func<T, T1>> sort)
        {
            //Get data count
            var count = await Count();
            if (count == 0)
                return default;

            return await _table.OrderBy(sort).LastAsync<T>();
        }

        public async Task<T> Last<T1>(Expression<Func<T, bool>> condition, Expression<Func<T, T1>> sort)
        {
            //Get data count
            var count = await Count();
            if (count == 0)
                return default;

            //Get last data
            var result = _table.Where(condition).OrderBy(sort);
            if(result == null || result.Count() == 0)
            {
                return default;
            }

            return await result.LastAsync<T>();
        }

        public async Task<T> Find(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await _table.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Update(object id, object entities)
        {
            //Find data to update
            var result = await Find(id);

            //Check if the data exist
            if (result == null)
                throw new Exception(Constants.ERROR_DATA_NOT_FOUND);

            //Do Update
            _db.Entry(result).CurrentValues.SetValues(entities);
            await _db.SaveChangesAsync();
        }
    }
}
