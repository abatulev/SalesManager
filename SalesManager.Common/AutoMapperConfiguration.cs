using AutoMapper;
using SalesManager.BLL;
using SalesManager.ViewModels;

namespace SalesManager.Common
{
    /// <summary>
    /// AutoMapper configuration class
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Configures IMapper.
        /// </summary>
        /// <returns>IMapper</returns>
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
                c.AddProfile(new ViewModelsMappingProfile());
            });

            return config.CreateMapper();
        }
    }
}
