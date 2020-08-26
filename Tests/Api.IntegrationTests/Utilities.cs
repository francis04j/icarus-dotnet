using System;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Entities;
using Newtonsoft.Json;
using Persistence;

namespace Api.IntegrationTests
{
    public class Utilities
    {
        public static void InitializeDbForTests(RecoupDbContext context)
        {
            context.WeatherForecasts.Add(new WeatherForecastt
            {
                WeatherForecasttId = Guid.NewGuid(),
                Date = DateTime.Now,
                Summary = "Weather for today",
                TemperatureC = 32
            });

            context.Episodes.Add(new Episode
            {
                EpisodeId = Guid.Empty,
                Title = "Test"
            });

            context.Episodes.Add(new Episode
            {
                EpisodeId = Guid.Empty,
                Title = "Test1"
            });

            context.SaveChanges();
        }

        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }
    }
}