using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PodcastWebApi.Application.Common.Interfaces;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RecoupDbContext>(options =>
              //  options.UseSqlServer(configuration.GetConnectionString("Cloud")
              //      ));
             options.UseInMemoryDatabase("RecoupDatabase"));
            //UseSqlServer(configuration.GetConnectionString("NorthwindDatabase")));

            services.AddScoped<IAppDbContext>(provider => provider.GetService<RecoupDbContext>());

            return services;
        }
    }
}
