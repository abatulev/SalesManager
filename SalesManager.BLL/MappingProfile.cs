using SalesManager.BLL.DTO;
using SalesManager.Models;

namespace SalesManager.BLL
{
    /// <summary>
    /// Current project automapper profile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Window, WindowDTO>().ReverseMap();
            CreateMap<SubElement, SubElementDTO>().ReverseMap();
        }
    }
}
