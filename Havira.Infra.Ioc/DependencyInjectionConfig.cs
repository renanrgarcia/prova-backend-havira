using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Havira.Application.App.ContextoLocalizacao;
using Havira.Application.Interfaces.ContextoLocalizacao;
using Havira.Data.Context;
using Havira.Business.Interfaces.ContextoLocalizacao;
using Havira.Data.Repository.ContextoLocalizacao;
using Havira.Business.Interfaces;
using Havira.Business.Notificacoes;

namespace Havira.Infra.Ioc
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<MeuDbContext>();

            services.AddScoped<ILocalizacaoRepository, LocalizacaoRepository>();

            services.AddScoped<ILocalizacaoApplication, LocalizacaoApplication>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}