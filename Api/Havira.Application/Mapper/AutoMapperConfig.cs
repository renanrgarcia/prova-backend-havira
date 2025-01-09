using AutoMapper;
using Havira.Application.ViewModel.ContextFeature;
using Havira.Business.Models.ContextFeature;
using NetTopologySuite.Geometries;
using static Havira.Business.Models.ContextFeature.Feature;

namespace Havira.Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Feature, GetFeatureViewModel>()
                .ForMember(dest => dest.Geometry, opt => opt.MapFrom(src => new GeoJsonPoint
                {
                    Type = "Point",
                    Coordinates = new double[] { src.Geometry.X, src.Geometry.Y }
                }))
                .ReverseMap();

            CreateMap<CreateOrUpdateFeatureViewModel, Feature>()
            .ForMember(dest => dest.Geometry, opt => opt.MapFrom(src =>
                NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326)
                .CreatePoint(new Coordinate(src.Longitude, src.Latitude))))
            .ReverseMap();
        }
    }
}