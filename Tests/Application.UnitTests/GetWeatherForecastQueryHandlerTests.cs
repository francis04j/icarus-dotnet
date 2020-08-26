using System;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Xunit;
using AutoMapper;
using Common;
using Moq;
using Shouldly;
using PodcastWebApi.Application.WeatherForecast.Queries.GetWeatherForecast;

namespace Application.UnitTests
{
    public class GetWeatherForecastQueryHandlerTests
    {
        private readonly RecoupDbContext _context;
        private readonly IMapper _mapper;
        private readonly DateTime _dateTime;
        private readonly Mock<IDateTime> _dateTimeMock;
        public GetWeatherForecastQueryHandlerTests()
        {

            _dateTime = new DateTime(2020, 7, 5);
            _dateTimeMock = new Mock<IDateTime>();
            _dateTimeMock.Setup(x => x.Now).Returns(_dateTime);

            QueryTestFixture fixture = new QueryTestFixture(_dateTimeMock.Object);
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task ShouldGetWeatherForecast()
        {
            var sut = new GetWeatherForecastQueryHandler(_context, _mapper);

            var result = await sut.Handle(
                new GetWeatherForecastQuery()
                {
                    Date = _dateTime.Date
                }, CancellationToken.None);

            result.ShouldBeOfType<WeatherForecastVm>();
            result.Date.ShouldBe(_dateTime);
        }
    }
}