using AutoMapper;
using Havira.Application.ViewModel.ContextFeature;
using Havira.Business.Models.ContextFeature;

namespace Havira.Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Feature, FeatureViewModel>()
                .ReverseMap();
        }
    }
}