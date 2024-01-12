using Microsoft.EntityFrameworkCore;
using SalesManager.Models;
using SalesManager.Models.BaseModels;

namespace SalesManager.DAL.DatabaseContext
{
    /// <inheritdoc/>
    public class SalesManagerContext : DbContext, ISalesManagerContext
    {
        /// <summary>
        /// List of Order items.
        /// </summary>
        /// <value>
        /// The Order items.
        /// </value>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// List of Window items.
        /// </summary>
        /// <value>
        /// The Window items.
        /// </value>
        public DbSet<Window> Windows { get; set; }

        /// <summary>
        /// List of SubElement items.
        /// </summary>
        /// <value>
        /// The SubElement items.
        /// </value>
        public DbSet<SubElement> SubElements { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoEduContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public SalesManagerContext(DbContextOptions<SalesManagerContext> options) : base(options)
        {
        }

        /// <inheritdoc/>
        public DbSet<T> DbSet<T>() where T : BaseEntity
        {
            return Set<T>();
        }

        /// <inheritdoc/>
        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }
    }
}
