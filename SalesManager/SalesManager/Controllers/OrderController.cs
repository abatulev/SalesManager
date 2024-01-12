using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesManager.BLL.DTO;
using SalesManager.BLL.Interfaces;
using SalesManager.ViewModels;

namespace SalesManager.Controllers
{
    /// <summary>
    /// The order controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService orderService;
        IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="orderService">The order service.</param>
        /// <param name="mapper">The mapper.</param>
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the all orders.
        /// </summary>
        /// <returns>A Task.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetAllOrders()
        {
            var orders = await orderService.GetAllOrdersAsync();
            if (orders != null)
            {
                return Ok(mapper.Map<IEnumerable<OrderViewModel>>(orders));
            }

            return StatusCode(500, "Internal server error");
        }

        /// <summary>
        /// Gets the order by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        [Route("GetOrderById/{id}")]
        [HttpGet]
        public async Task<ActionResult<OrderViewModel>> GetOrderById(int id)
        {
            var order = await orderService.GetOrderByIdAsync(id);
            if (order != null)
            {
                return Ok(mapper.Map<OrderViewModel>(order));
            }

            return StatusCode(500, "Internal server error");
        }

        /// <summary>
        /// Create new order.
        /// </summary>
        /// <param name="orderModel">The order model.</param>
        /// <returns>A Task.</returns>
        [HttpPost]
        public async Task<ActionResult> PostOrder([FromBody] OrderViewModel orderModel)
        {
            try
            {
                if (orderModel == null)
                {
                    return BadRequest("Order object is null");
                }


                await orderService.CreateOrderAsync(mapper.Map<OrderDTO>(orderModel));

                return Ok(orderModel);
            }
            catch (Exception ex)
            {
                //TODO "Something went wrong inside PostOrder action: {ex.Message}";
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Update the order.
        /// </summary>
        /// <param name="orderModel">The order model.</param>
        /// <returns>A Task.</returns>
        [HttpPut]
        public async Task<ActionResult> PutOrder([FromBody] OrderViewModel orderModel)
        {
            try
            {
                if (orderModel == null)
                {
                    return BadRequest("Order object is null");
                }

                await orderService.UpdateOrderAsync(mapper.Map<OrderDTO>(orderModel));

                return Ok(orderModel);
            }
            catch (Exception ex)
            {
                //TODO
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            try
            {
                await orderService.DeleteOrderAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                //TODO
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
