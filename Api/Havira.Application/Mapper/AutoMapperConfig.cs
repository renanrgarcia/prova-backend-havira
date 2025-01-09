using System.Drawing;
using AutoMapper;
using Havira.Application.ViewModel.ContextFeature;
using Havira.Business.Models.ContextFeature;
using static Havira.Business.Models.ContextFeature.Feature;

namespace Havira.Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Feature, GetFeatureViewModel>()
                .ForMember(dest => dest.Point, opt => opt.MapFrom(src => new GeoJsonPoint
                {
                    Type = "Point",
                    Coordinates = new double[] { src.Point.X, src.Point.Y }
                }))
                .ReverseMap();

            CreateMap<Feature, CreateFeatureViewModel>()
                .ForMember(dest => dest.Point, opt => opt.MapFrom(src => new GeoJsonPoint
                {
                    Type = "Point",
                    Coordinates = new double[] { src.Point.X, src.Point.Y }
                }))
                .ReverseMap();
        }
    }
}