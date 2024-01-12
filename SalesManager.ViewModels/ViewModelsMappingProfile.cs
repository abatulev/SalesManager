using SalesManager.BLL.DTO;

namespace SalesManager.ViewModels
{
    /// <summary>
    /// Current project automapper profile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ViewModelsMappingProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public ViewModelsMappingProfile()
        {
            CreateMap<OrderViewModel, OrderDTO>().ReverseMap();
            CreateMap<WindowViewModel, WindowDTO>().ReverseMap();
            CreateMap<SubElementViewModel, SubElementDTO>().ReverseMap();
        }
    }
}
