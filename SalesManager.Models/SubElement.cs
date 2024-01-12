using SalesManager.Models.BaseModels;

namespace SalesManager.Models
{
    /// <summary>
    /// The sub element.
    /// </summary>
    public class SubElement : BaseEntity
    {
        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        public int Element { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
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
    }
}
