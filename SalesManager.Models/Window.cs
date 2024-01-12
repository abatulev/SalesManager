using SalesManager.Models.BaseModels;

namespace SalesManager.Models
{
    /// <summary>
    /// The window.
    /// </summary>
    public class Window : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the quantity of windows.
        /// </summary>
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
        public ICollection<SubElement> SubElements { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        public Window()
        {
            SubElements = new List<SubElement>();
        }
    }
}
