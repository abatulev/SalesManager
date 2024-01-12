using Microsoft.EntityFrameworkCore;
using SalesManager.DAL.DatabaseContext;
using SalesManager.Models.BaseModels;
using System.Linq.Expressions;

namespace SalesManager.BLL.Base
{
    /// <inheritdoc/>
    public class BaseService : IBaseService, IDisposable
    {
        protected ISalesManagerContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public BaseService(ISalesManagerContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity =>
            await dbContext.DbSet<T>().FirstOrDefaultAsync(predicate);

        /// <inheritdoc/>
        public async Task<T> GetWithoutTrackingAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity =>
            await dbContext.DbSet<T>().AsNoTracking().FirstOrDefaultAsync(predicate);

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseEntity =>
            await dbContext.DbSet<T>().ToListAsync();

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetAllByExpressionAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity =>
            await dbContext.DbSet<T>().Where(predicate).ToListAsync();

        /// <inheritdoc/>
        public async Task DeleteAsync<T>(T entity) where T : BaseEntity
        {
            dbContext.DbSet<T>().Remove(entity);
            await dbContext.SaveAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAllAsync<T>() where T : BaseEntity
        {
            var dbSet = dbContext.DbSet<T>();
            dbSet.RemoveRange(dbSet);
            await dbContext.SaveAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            dbContext.DbSet<T>().Update(entity);
            await dbContext.SaveAsync();
        }

        /// <inheritdoc/>
        public async Task CreateAsync<T>(T entity) where T : BaseEntity
        {
            dbContext.DbSet<T>().Add(entity);
            await dbContext.SaveAsync();
        }

        /// <summary>
        /// Disposes the.
        /// </summary>
        public void Dispose() =>
            dbContext.Dispose();
    }
}
