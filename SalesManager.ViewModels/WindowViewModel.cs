using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SalesManager.ViewModels
{
    /// <summary>
    /// The window view model.
    /// </summary>
    public class WindowViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        [MaxLength(30, ErrorMessage = "Name must not contain more than 30 characters")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the quantity of windows.
        /// </summary>
        [Required]
        public int QuantityOfWindows { get; set; }

        /// <summary>
        /// Gets or sets the total sub elements.
        /// </summary>
        public int TotalSubElements { get; set; }

        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the sub elements.
        /// </summary>
        public ICollection<SubElementViewModel> SubElements { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowViewModel"/> class.
        /// </summary>
        public WindowViewModel()
        {
            SubElements = new List<SubElementViewModel>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether is editing.
        /// </summary>
        [JsonIgnore]
        public bool IsEditing { get; set; }
    }
}
