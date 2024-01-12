using SalesManager.BLL.DTO;

namespace SalesManager.BLL.Interfaces
{
    /// <summary>
    /// The window service.
    /// </summary>
    public interface IWindowService
    {
        /// <summary>
        /// Gets the all windows async.
        /// </summary>
        /// <returns>A Task.</returns>
        public Task<IEnumerable<WindowDTO>> GetAllWindowsAsync();

        /// <summary>
        /// Gets the all windows by order id async.
        /// </summary>
        /// <param name="orderId">The order id.</param>
        /// <returns>A Task.</returns>
        public Task<IEnumerable<WindowDTO>> GetAllWindowsByOrderIdAsync(int orderId);

        /// <summary>
        /// Gets the window by id async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task<WindowDTO> GetWindowByIdAsync(int id);

        /// <summary>
        /// Gets the window by id without tracking async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task<WindowDTO> GetWindowByIdWithoutTrackingAsync(int id);

        /// <summary>
        /// Creates the window async.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns>A Task.</returns>
        public Task CreateWindowAsync(WindowDTO window);

        /// <summary>
        /// Updates the window async.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns>A Task.</returns>
        public Task UpdateWindowAsync(WindowDTO window);

        /// <summary>
        /// Deletes the window async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task DeleteWindowAsync(int id);
    }
}
