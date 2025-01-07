using AutoMapper;
using Havira.Application.ViewModel.ContextoFeature;
using Havira.Business.Models.ContextoFeature;

namespace Havira.Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Feature, FeatureViewModel>()
                .ForMember(x => x.Properties, map => map.MapFrom(prop => prop.Properties))
                .ReverseMap();

            CreateMap<Properties, PropertiesViewModel>()
                .ReverseMap();
        }
    }
}