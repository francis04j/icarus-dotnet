using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using PodcastWebApi.Application.Common.Interfaces;

namespace PodcastWebApi.Application.System.Command.SeedSampleData
{
    public class SampleDataSeeder
    {
        private readonly IAppDbContext _context;

        public SampleDataSeeder(IAppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            if (_context.WeatherForecasts.Any())
            {
                return;
            }

            await SeedWeatherForecastsAsync(cancellationToken);
            await SeedEpisodesAsync(cancellationToken);
        }

        private async Task SeedWeatherForecastsAsync(CancellationToken cancellationToken)
        {
            var weathers = new[]
            {
                new WeatherForecastt
                {
                    WeatherForecasttId = Guid.NewGuid(), Date = new DateTime(2020, 9, 4),
                    Summary = "Test", TemperatureC = 32
                }
            };

            _context.WeatherForecasts.AddRange(weathers);
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedEpisodesAsync(CancellationToken cancellationToken)
        {
            var episodes = new[]
            {
                new Episode
                {
                    EpisodeId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                    Title = "Test"
                }
            };

            _context.Episodes.AddRange(episodes);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}