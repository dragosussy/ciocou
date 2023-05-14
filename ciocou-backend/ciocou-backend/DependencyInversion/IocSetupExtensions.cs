using Data;
using Data.DbContext;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Repository;

namespace DependencyInversion
{
    public static class IocSetupExtensions
    {
        public static void AddDataLayer(this IServiceCollection services)
        {
            services.AddDbContext<CiocouPostgresDbContext>();

            services.AddScoped<ICioccEventRepository, CioccEventRepository>();
            
            services.AddScoped<EasterService>();
        }
    }
}
