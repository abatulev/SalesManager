using SalesManager.Models.BaseModels;
using System.Linq.Expressions;

namespace SalesManager.BLL.Base
{
    /// <summary>
    /// Base service for working with DB
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// Get generic object from the database.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the BaseEntity class.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns one item entity by type T appropriate the condition.
        /// </returns>
        Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        /// <summary>
        /// Get generic object from the database without tracking.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the BaseEntity class.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns one item entity by type T appropriate the condition.
        /// </returns>
        Task<T> GetWithoutTrackingAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        /// <summary>
        /// Get list of generic objects.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the BaseEntity class.</typeparam>
        /// <returns>
        /// Returns list with all entity by type T.
        /// </returns>
        Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseEntity;

        /// <summary>
        /// Get list of generic objects.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the BaseEntity class.</typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns list with all entity by type T appropriate the condition.
        /// </returns>
        Task<IEnumerable<T>> GetAllByExpressionAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        /// <summary>
        /// Delete provided generic object.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the BaseEntity class.</typeparam>
        /// <param name="entity">The entity.</param>
        Task DeleteAsync<T>(T entity) where T : BaseEntity;

        /// <summary>
        /// Delete all provided generic object.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the BaseEntity class.</typeparam>
        Task DeleteAllAsync<T>() where T : BaseEntity;

        /// <summary>
        /// Update provided generic object.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the BaseEntity class.</typeparam>
        /// <param name="entity">The entity.</param>
        Task UpdateAsync<T>(T entity) where T : BaseEntity;

        /// <summary>
        /// Create provided generic object.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the BaseEntity class.</typeparam>
        /// <param name="entity">The entity.</param>
        Task CreateAsync<T>(T entity) where T : BaseEntity;
    }
}
