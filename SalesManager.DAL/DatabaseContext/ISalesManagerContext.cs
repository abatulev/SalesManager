using Microsoft.EntityFrameworkCore;
using SalesManager.Models.BaseModels;

namespace SalesManager.DAL.DatabaseContext
{
    /// <summary>
    /// Database context
    /// </summary>
    public interface ISalesManagerContext
    {
        /// <summary>
        /// The database set.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the BaseEntity class.</typeparam>
        /// <returns></returns>
        DbSet<T> DbSet<T>() where T : BaseEntity;

        /// <summary>
        /// Save changes.
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();

        /// <summary>
        /// Release unmanaged and - optionally - managed resources.
        /// </summary>
        void Dispose();
    }
}
