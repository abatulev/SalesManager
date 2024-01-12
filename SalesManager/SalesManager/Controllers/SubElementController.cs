using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesManager.BLL.DTO;
using SalesManager.BLL.Interfaces;
using SalesManager.ViewModels;

namespace SalesManager.Controllers
{
    /// <summary>
    /// The sub element controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubElementController : ControllerBase
    {
        ISubElementService subElementService;
        IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubElementController"/> class.
        /// </summary>
        /// <param name="subElementService">The sub element service.</param>
        /// <param name="mapper">The mapper.</param>
        public SubElementController(ISubElementService subElementService, IMapper mapper)
        {
            this.subElementService = subElementService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the sub elementss by window id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        [Route("SubElementsByWindowId/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubElementViewModel>>> GetSubElementssByWindowId(int id)
        {
            var subElements = await subElementService.GetAllSubElementsByWindowIdAsync(id);
            if (subElements != null)
            {
                return Ok(mapper.Map<IEnumerable<SubElementViewModel>>(subElements));
            }
            //TODO
            return StatusCode(500, "Internal server error");
        }

        /// <summary>
        /// Create new sub element.
        /// </summary>
        /// <param name="subElementModel">The sub element model.</param>
        /// <returns>A Task.</returns>
        [HttpPost]
        public async Task<ActionResult> PostSubElement([FromBody] SubElementViewModel subElementModel)
        {
            try
            {
                if (subElementModel == null)
                {
                    return BadRequest("SubElement object is null");
                }


                await subElementService.CreateSubElementAsync(mapper.Map<SubElementDTO>(subElementModel));

                return Ok(subElementModel);
            }
            catch (Exception ex)
            {
                //TODO
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Update the sub element.
        /// </summary>
        /// <param name="subElementModel">The sub element model.</param>
        /// <returns>A Task.</returns>
        [HttpPut]
        public async Task<ActionResult> PutSubElement([FromBody] SubElementViewModel subElementModel)
        {
            try
            {
                if (subElementModel == null)
                {
                    return BadRequest("Order object is null");
                }

                await subElementService.UpdateSubElementAsync(mapper.Map<SubElementDTO>(subElementModel));

                return Ok(subElementModel);
            }
            catch (Exception ex)
            {
                //TODO
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes the sub element.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Task.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubElement(int id)
        {
            try
            {
                await subElementService.DeleteSubElementAsync(id);
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
