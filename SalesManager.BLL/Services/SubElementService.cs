using AutoMapper;
using SalesManager.BLL.Base;
using SalesManager.BLL.DTO;
using SalesManager.BLL.Interfaces;
using SalesManager.Models;

namespace SalesManager.BLL.Services
{
    /// <inheritdoc/>
    public class SubElementService : ISubElementService
    {
        private readonly IBaseService baseService;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubElementService"/> class.
        /// </summary>
        /// <param name="baseService">The base service.</param>
        /// <param name="mapper">The mapper.</param>
        public SubElementService(IBaseService baseService, IMapper mapper)
        {
            this.baseService = baseService;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SubElementDTO>> GetAllSubElementsAsync() =>
            mapper.Map<IEnumerable<SubElementDTO>>(await baseService.GetAllAsync<SubElement>());

        /// <inheritdoc/>
        public async Task<IEnumerable<SubElementDTO>> GetAllSubElementsByWindowIdAsync(int windowId) =>
            mapper.Map<IEnumerable<SubElementDTO>>(await baseService.GetAllByExpressionAsync<SubElement>(w => w.WindowId == windowId));

        /// <inheritdoc/>
        public async Task<SubElementDTO> GetSubElementByIdAsync(int id) =>
            mapper.Map<SubElementDTO>(await baseService.GetAsync<SubElement>(o => o.Id == id));

        /// <inheritdoc/>
        public async Task<SubElementDTO> GetSubElementByIdWithoutTrackingAsync(int id) =>
            mapper.Map<SubElementDTO>(await baseService.GetWithoutTrackingAsync<SubElement>(o => o.Id == id));

        /// <inheritdoc/>
        public async Task CreateSubElementAsync(SubElementDTO subElement)
        {
            await baseService.CreateAsync(mapper.Map<SubElement>(subElement));

            var window = await baseService.GetWithoutTrackingAsync<Window>(w => w.Id == subElement.WindowId); //TODO
            var countSubElements = (await baseService.GetAllByExpressionAsync<SubElement>(s => s.WindowId == subElement.WindowId)).Count();
            window.TotalSubElements = countSubElements;
            await baseService.UpdateAsync<Window>(window);
        }

        /// <inheritdoc/>
        public async Task UpdateSubElementAsync(SubElementDTO subElement) =>
            await baseService.UpdateAsync<SubElement>(mapper.Map<SubElement>(subElement));

        /// <inheritdoc/>
        public async Task DeleteSubElementAsync(int id)
        {
            var subElement = await GetSubElementByIdWithoutTrackingAsync(id);
            await baseService.DeleteAsync<SubElement>(mapper.Map<SubElement>(subElement));

            var window = await baseService.GetWithoutTrackingAsync<Window>(w => w.Id == subElement.WindowId); //TODO
            var countSubElements = (await baseService.GetAllByExpressionAsync<SubElement>(s => s.WindowId == subElement.WindowId)).Count();
            window.TotalSubElements = countSubElements;
            await baseService.UpdateAsync<Window>(window);
        }
    }
}
