using System.ComponentModel.DataAnnotations;

namespace SalesManager.Models.BaseModels
{
    /// <summary>
    /// Base entity
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// The item identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }
    }
}
