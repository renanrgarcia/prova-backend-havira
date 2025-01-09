using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Havira.Application.App.ContextFeature;
using Havira.Application.Interfaces.ContextFeature;
using Havira.Data.Context;
using Havira.Business.Interfaces.ContextFeature;
using Havira.Data.Repository.ContextFeature;
using Havira.Business.Interfaces;
using Havira.Business.Helpers.Notification;
using Havira.Business.Helpers;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace Havira.Infra.Ioc
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<MyDbContext>();

            services.AddScoped<IFeatureRepository, FeatureRepository>();

            services.AddScoped<IFeatureApplication, FeatureApplication>();
            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<IGeoJsonHelper, GeoJsonHelper>();

            return services;
        }
    }
}