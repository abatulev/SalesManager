namespace SalesManager.BLL.DTO
{
    /// <summary>
    /// The order d t o.
    /// </summary>
    public class OrderDTO
    {
        /// <summary>
        /// Gets or sets the i d.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the windows.
        /// </summary>
        public ICollection<WindowDTO> Windows { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDTO"/> class.
        /// </summary>
        public OrderDTO()
        {
            Windows = new List<WindowDTO>();
        }
    }
}
