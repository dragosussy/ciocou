using Data;
using Data.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Middleware.ExceptionHandler;
using Service;
using Service.Repository;

namespace DependencyInversion
{
    public static class IocSetupExtensions
    {
        public static void AddCustomMiddleware(this IApplicationBuilder app) 
        {
            app.UseMiddleware<CioccExceptionHandlerMiddleware>();
        }

        public static void AddCustom(this IServiceCollection services)
        {
            services.AddScoped<ICioccEventRepository, CioccEventRepository>();

            services.AddScoped<EasterService>();
        }

        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<CiocouPostgresDbContext>(options =>
                options
                    .UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention()
            );
    }
}
