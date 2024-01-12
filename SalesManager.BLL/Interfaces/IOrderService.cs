using SalesManager.BLL.DTO;

namespace SalesManager.BLL.Interfaces
{
    /// <summary>
    /// The order service.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Gets the all orders async.
        /// </summary>
        /// <returns>A Task.</returns>
        public Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();

        /// <summary>
        /// Gets the order by id async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task<OrderDTO> GetOrderByIdAsync(int id);

        /// <summary>
        /// Gets the order by id without tracking async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task<OrderDTO> GetOrderByIdWithoutTrackingAsync(int id);

        /// <summary>
        /// Creates the order async.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>A Task.</returns>
        public Task CreateOrderAsync(OrderDTO order);

        /// <summary>
        /// Updates the order async.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>A Task.</returns>
        public Task UpdateOrderAsync(OrderDTO order);

        /// <summary>
        /// Deletes the order async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task DeleteOrderAsync(int id);
    }
}
