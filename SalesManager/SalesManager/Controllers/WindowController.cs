using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesManager.BLL.DTO;
using SalesManager.BLL.Interfaces;
using SalesManager.ViewModels;

namespace SalesManager.Controllers
{
    /// <summary>
    /// The window controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        IWindowService windowService;
        IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowController"/> class.
        /// </summary>
        /// <param name="windowService">The window service.</param>
        /// <param name="mapper">The mapper.</param>
        public WindowController(IWindowService windowService, IMapper mapper)
        {
            this.windowService = windowService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the windows by order id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        [Route("GetWindowsByOrderId/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WindowViewModel>>> GetWindowsByOrderId(int id)
        {
            var windows = await windowService.GetAllWindowsByOrderIdAsync(id);
            if (windows != null)
            {
                return Ok(mapper.Map<IEnumerable<WindowViewModel>>(windows));
            }

            return StatusCode(500, "Internal server error");
        }

        /// <summary>
        /// Gets the window by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        [Route("GetWindowById/{id}")]
        [HttpGet]
        public async Task<ActionResult<WindowViewModel>> GetWindowById(int id)
        {
            var window = await windowService.GetWindowByIdAsync(id);
            if (window != null)
            {
                return Ok(mapper.Map<WindowViewModel>(window));
            }
            //TODO
            return StatusCode(500, "Internal server error");
        }

        /// <summary>
        /// Create new window.
        /// </summary>
        /// <param name="windowModel">The window model.</param>
        /// <returns>A Task.</returns>
        [HttpPost]
        public async Task<ActionResult> PostWindow([FromBody] WindowViewModel windowModel)
        {
            try
            {
                if (windowModel == null)
                {
                    return BadRequest("Order object is null");
                }


                await windowService.CreateWindowAsync(mapper.Map<WindowDTO>(windowModel));

                return Ok(windowModel);
            }
            catch (Exception ex)
            {
                //TODO 
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Update the window.
        /// </summary>
        /// <param name="windowModel">The window model.</param>
        /// <returns>A Task.</returns>
        [HttpPut]
        public async Task<ActionResult> PutWindow([FromBody] WindowViewModel windowModel)
        {
            try
            {
                if (windowModel == null)
                {
                    return BadRequest("Order object is null");
                }

                await windowService.UpdateWindowAsync(mapper.Map<WindowDTO>(windowModel));

                return Ok(windowModel);
            }
            catch (Exception ex)
            {
                //TODO
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes the window.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWindow(int id)
        {
            try
            {
                await windowService.DeleteWindowAsync(id);
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
