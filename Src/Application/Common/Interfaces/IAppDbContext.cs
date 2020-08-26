using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace PodcastWebApi.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<WeatherForecastt> WeatherForecasts { get; set; }
        DbSet<Domain.Entities.Episode> Episodes { get; set; }
        void AddEpisode(Domain.Entities.Episode episode);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
