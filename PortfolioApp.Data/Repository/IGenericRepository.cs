using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace PortfolioApp.Data.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query();
        IQueryable<T> QueryAsNoTracking();
        Task<T?> GetByIdAsync(int id);
        Task<T?> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate = null!,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<IEnumerable<T>> GetListAsync(
            Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
