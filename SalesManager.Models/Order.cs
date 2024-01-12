using SalesManager.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManager.Models
{
    /// <summary>
    /// The order.
    /// </summary>
    public class Order : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the windows.
        /// </summary>
        public ICollection<Window> Windows { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order()
        {
            Windows = new List<Window>();
        }
    }
}
