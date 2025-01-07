using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Havira.Application.App.ContextoFeature;
using Havira.Application.Interfaces.ContextoFeature;
using Havira.Data.Context;
using Havira.Business.Interfaces.ContextoFeature;
using Havira.Data.Repository.ContextoFeature;
using Havira.Business.Interfaces;
using Havira.Business.Notificacoes;

namespace Havira.Infra.Ioc
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<MeuDbContext>();

            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IPropertiesRepository, PropertiesRepository>();

            services.AddScoped<IFeatureApplication, FeatureApplication>();
            services.AddScoped<IPropertiesApplication, PropertiesApplication>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}