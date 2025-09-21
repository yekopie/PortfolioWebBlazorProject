using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace PortfolioApp.Data.Repository
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> Query();
        IQueryable<T> QueryAsNoTracking();
        Task<T?> GetByIdAsync(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<T?> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate = null!,
            params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetListAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
