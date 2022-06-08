using AutoMapper;

namespace Impulse.Domain.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(o =>
            {
                o.AddProfile<DomainToViewModelMappingProfile>();
                o.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}