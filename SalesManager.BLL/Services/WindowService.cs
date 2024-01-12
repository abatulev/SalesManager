using AutoMapper;
using SalesManager.BLL.Base;
using SalesManager.BLL.DTO;
using SalesManager.BLL.Interfaces;
using SalesManager.Models;

namespace SalesManager.BLL.Services
{
    /// <inheritdoc/>
    public class WindowService : IWindowService
    {
        private readonly IBaseService baseService;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowService"/> class.
        /// </summary>
        /// <param name="baseService">The base service.</param>
        /// <param name="mapper">The mapper.</param>
        public WindowService(IBaseService baseService, IMapper mapper)
        {
            this.baseService = baseService;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<WindowDTO>> GetAllWindowsAsync() =>
            mapper.Map<IEnumerable<WindowDTO>>(await baseService.GetAllAsync<Window>());

        /// <inheritdoc/>
        public async Task<IEnumerable<WindowDTO>> GetAllWindowsByOrderIdAsync(int orderId) =>
            mapper.Map<IEnumerable<WindowDTO>>(await baseService.GetAllByExpressionAsync<Window>(w => w.OrderId == orderId));

        /// <inheritdoc/>
        public async Task<WindowDTO> GetWindowByIdAsync(int id) =>
            mapper.Map<WindowDTO>(await baseService.GetAsync<Window>(o => o.Id == id));

        /// <inheritdoc/>
        public async Task<WindowDTO> GetWindowByIdWithoutTrackingAsync(int id) =>
            mapper.Map<WindowDTO>(await baseService.GetWithoutTrackingAsync<Window>(o => o.Id == id));

        /// <inheritdoc/>
        public async Task CreateWindowAsync(WindowDTO window) =>
            await baseService.CreateAsync(mapper.Map<Window>(window));

        /// <inheritdoc/>
        public async Task UpdateWindowAsync(WindowDTO window) =>
            await baseService.UpdateAsync<Window>(mapper.Map<Window>(window));

        /// <inheritdoc/>
        public async Task DeleteWindowAsync(int id)
        {
            var window = await GetWindowByIdWithoutTrackingAsync(id);
            await baseService.DeleteAsync<Window>(mapper.Map<Window>(window));
        }
    }
}
