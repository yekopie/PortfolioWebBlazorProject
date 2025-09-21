using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PortfolioApp.Data.Context;
using System.Linq.Expressions;

namespace PortfolioApp.Data.Repository
{
    public class EfGenericRepository<T>(AppDbContext dbContext) : IGenericRepository<T> where T : class
    {
        private DbSet<T> _dbSet = dbContext.Set<T>();
        public IQueryable<T> Query() => dbContext.Set<T>();
        public IQueryable<T> QueryAsNoTracking() => dbContext.Set<T>().AsNoTracking();

        public async Task AddAsync(T entity)
        {

            await _dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task<List<T>> GetListAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = QueryAsNoTracking();
            foreach (var include in includes)
                query = query.Include(include);
            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {

            return await _dbSet.FindAsync(id);
        }


        public async Task<T?> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate = null!,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = QueryAsNoTracking();

            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
