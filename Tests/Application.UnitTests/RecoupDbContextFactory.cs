using System;
using Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.UnitTests
{
    public class RecoupDbContextFactory
    {
        public static RecoupDbContext Create(IDateTime dateTime)
        {
            var options = new DbContextOptionsBuilder<RecoupDbContext>().UseInMemoryDatabase(
                    Guid.NewGuid().ToString())
                .Options;
            var context = new RecoupDbContext(options);

            context.Database.EnsureCreated();

            context.WeatherForecasts.AddRange(new[] {
                new WeatherForecastt() { WeatherForecasttId = Guid.NewGuid(), Date = dateTime.Now, Summary = "Weather A", TemperatureC = 32}
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(RecoupDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}