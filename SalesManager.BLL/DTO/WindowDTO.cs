namespace SalesManager.BLL.DTO
{
    /// <summary>
    /// The window d t o.
    /// </summary>
    public class WindowDTO
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

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
        public ICollection<SubElementDTO> SubElements { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowDTO"/> class.
        /// </summary>
        public WindowDTO()
        {
            SubElements = new List<SubElementDTO>();
        }
    }
}
