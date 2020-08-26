using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PodcastWebApi.Application.Common.Interfaces;

namespace Recoup.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<INotificationService, NotificationService>();
            return services;
        }
    }
}