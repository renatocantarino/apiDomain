using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => {  
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
    #if DEBUG
                cfg.ForAllMaps((map, expression) => { map.ConfiguredMemberList = MemberList.Destination; });
    #endif
            });

#if DEBUG
            mapperConfiguration.AssertConfigurationIsValid();
#endif
            return mapperConfiguration;
        }

    }
}