using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using Xunit;
using PodcastWebApi.Application.Common.Interfaces;
using Domain.Entities;
using Persistence;

namespace Persistence.IntegrationTests
{
    public class RecoupDbContextTests : IDisposable
    {
        private readonly RecoupDbContext _sut;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;
        private readonly string _userId;
        private readonly DateTime _dateTime;
        private readonly Mock<IDateTime> _dateTimeMock;

        public RecoupDbContextTests()
        {
            var options = new DbContextOptionsBuilder<RecoupDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _dateTime = new DateTime(3001, 1, 1);
            _dateTimeMock = new Mock<IDateTime>();
            _dateTimeMock.Setup(m => m.Now).Returns(_dateTime);

            _userId = "00000000-0000-0000-0000-000000000000";
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _currentUserServiceMock.Setup(m => m.UserId).Returns(_userId);

            _sut = new RecoupDbContext(options, _currentUserServiceMock.Object, _dateTimeMock.Object);
        }

        public void Dispose()
        {
            _sut?.Dispose();
        }

        [Fact]
        public async Task SaveChanges_GivenNewWeatherForecast_ShouldSetCreatedProperties()
        {
            var weather = new WeatherForecastt()
            {
              Date = DateTime.Now,
              TemperatureC = 21,
              Summary = "Temperate cool"
            };

            _sut.WeatherForecasts.Add(weather);

            await _sut.SaveChangesAsync();

            weather.Created.ShouldBe(_dateTime);
            weather.CreatedBy.ShouldBe(_userId);
        }


        [Fact]
        public async Task SaveChangesAsync_GivenExistingProduct_ShouldSetLastModifiedProperties()
        {
            var forecastId = Guid.NewGuid();
            _sut.WeatherForecasts.Add(new WeatherForecastt
            {
                WeatherForecasttId = forecastId,
                Date = DateTime.Now,
                TemperatureC = 21,
                Summary = "Temperate cool"
            });

            _sut.SaveChanges();

            var weatherForecastt = await _sut.WeatherForecasts.FindAsync(forecastId);

            weatherForecastt.Summary = "Better summary";

            await _sut.SaveChangesAsync();

            weatherForecastt.LastModified.ShouldNotBeNull();
            weatherForecastt.LastModified.ShouldBe(_dateTime);
            weatherForecastt.LastModifiedBy.ShouldBe(_userId);
        }
    }
}