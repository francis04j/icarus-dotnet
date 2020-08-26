using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Xunit;

namespace Api.IntegrationTests.Episodes
{
    public class Get : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Get(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsEpisodeViewModel()
        {
            var client = _factory.GetHttpClient();
            var response = await client.GetAsync("/api/episodes/get?Limit=0");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<IEnumerable<Episode>>(response);

            Assert.IsType<List<Episode>>(vm);
        }
    }
}