using SalesManager.BLL.DTO;

namespace SalesManager.BLL.Interfaces
{
    /// <summary>
    /// The sub element service.
    /// </summary>
    public interface ISubElementService
    {
        /// <summary>
        /// Gets the all sub elements async.
        /// </summary>
        /// <returns>A Task.</returns>
        public Task<IEnumerable<SubElementDTO>> GetAllSubElementsAsync();

        /// <summary>
        /// Gets the all sub elements by window id async.
        /// </summary>
        /// <param name="windowId">The window id.</param>
        /// <returns>A Task.</returns>
        public Task<IEnumerable<SubElementDTO>> GetAllSubElementsByWindowIdAsync(int windowId);

        /// <summary>
        /// Gets the sub element by id async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task<SubElementDTO> GetSubElementByIdAsync(int id);

        /// <summary>
        /// Gets the sub element by id without tracking async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task<SubElementDTO> GetSubElementByIdWithoutTrackingAsync(int id);

        /// <summary>
        /// Creates the sub element async.
        /// </summary>
        /// <param name="subElement">The sub element.</param>
        /// <returns>A Task.</returns>
        public Task CreateSubElementAsync(SubElementDTO subElement);

        /// <summary>
        /// Updates the sub element async.
        /// </summary>
        /// <param name="subElement">The sub element.</param>
        /// <returns>A Task.</returns>
        public Task UpdateSubElementAsync(SubElementDTO subElement);

        /// <summary>
        /// Deletes the sub element async.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        public Task DeleteSubElementAsync(int id);
    }
}
