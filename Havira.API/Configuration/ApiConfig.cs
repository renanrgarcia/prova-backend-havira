using Havira.Data.Context;
using Havira.Infra.Ioc;
using Microsoft.EntityFrameworkCore;


namespace Havira.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LocalizacaoConnection");

            if (!string.IsNullOrEmpty(connectionString))
            {
                services.AddDbContext<MeuDbContext>(options =>
                    options.UseNpgsql(connectionString));
            }

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.ResolveDependencies(configuration);

            services.AddSwaggerConfig();

            return services;
        }

        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsEnvironment("Hml"))
            {
                app.UseCors("Hml");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("Production");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}