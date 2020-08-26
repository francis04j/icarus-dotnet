using System.Threading.Tasks;
using PodcastWebApi.Application.WeatherForecast.Queries.GetWeatherForecast;
using Xunit;

namespace Api.IntegrationTests.WeatherForecast
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsWeatherForecastViewModel()
        {
            var client = _factory.GetHttpClient();
            var response = await client.GetAsync("/api/weatherforecast/getall");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<WeatherForecastVm>(response);

            Assert.IsType<WeatherForecastVm>(vm);
        }
    }
}