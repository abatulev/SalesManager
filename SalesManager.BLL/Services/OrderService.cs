using AutoMapper;
using SalesManager.BLL.Base;
using SalesManager.BLL.DTO;
using SalesManager.BLL.Interfaces;
using SalesManager.Models;

namespace SalesManager.BLL.Services
{
    /// <inheritdoc/>
    public class OrderService : IOrderService
    {
        private readonly IBaseService baseService;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="baseService">The base service.</param>
        /// <param name="mapper">The mapper.</param>
        public OrderService(IBaseService baseService, IMapper mapper)
        {
            this.baseService = baseService;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync() =>
            mapper.Map<IEnumerable<OrderDTO>>(await baseService.GetAllAsync<Order>());

        /// <inheritdoc/>
        public async Task<OrderDTO> GetOrderByIdAsync(int id) =>
            mapper.Map<OrderDTO>(await baseService.GetAsync<Order>(o => o.Id == id));

        /// <inheritdoc/>
        public async Task<OrderDTO> GetOrderByIdWithoutTrackingAsync(int id) =>
            mapper.Map<OrderDTO>(await baseService.GetWithoutTrackingAsync<Order>(o => o.Id == id));

        /// <inheritdoc/>
        public async Task CreateOrderAsync(OrderDTO order) =>
            await baseService.CreateAsync(mapper.Map<Order>(order));

        /// <inheritdoc/>
        public async Task UpdateOrderAsync(OrderDTO order) =>
            await baseService.UpdateAsync<Order>(mapper.Map<Order>(order));

        /// <inheritdoc/>
        public async Task DeleteOrderAsync(int id)
        {
            var order = await GetOrderByIdWithoutTrackingAsync(id);
            await baseService.DeleteAsync<Order>(mapper.Map<Order>(order));
        }
    }
}
