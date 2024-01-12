using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SalesManager.ViewModels
{
    /// <summary>
    /// The order view model.
    /// </summary>
    public class OrderViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters")]
        [MaxLength(30, ErrorMessage = "Name must not contain more than 30 characters")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [Required]
        [MinLength(2, ErrorMessage = "State must be at least 2 characters")]
        [MaxLength(10, ErrorMessage = "State must not contain more than 10 characters")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the windows.
        /// </summary>
        public ICollection<WindowViewModel> Windows { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderViewModel"/> class.
        /// </summary>
        public OrderViewModel()
        {
            Windows = new List<WindowViewModel>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether is editing.
        /// </summary>
        [JsonIgnore]
        public bool IsEditing { get; set; }
    }
}
