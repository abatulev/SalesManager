using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SalesManager.ViewModels
{
    /// <summary>
    /// The sub element view model.
    /// </summary>
    public class SubElementViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        public int Element { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [Required]
        [Range(1, 2, ErrorMessage = "Please, select the type")]
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the window id.
        /// </summary>
        public int WindowId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is editing.
        /// </summary>
        [JsonIgnore]
        public bool IsEditing { get; set; }
    }
}
