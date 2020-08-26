using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PodcastWebApi.Application.WeatherForecast.Queries.GetEpisode;
using PodcastWebApi.Application.Episodes.Commands;

namespace Api.Controllers
{
    public class EpisodesController : BaseController
    {
      

        [HttpGet]
        public async Task<ActionResult<GetEpisodeVm>> Get([FromQuery] GetEpisodeQuery query)
        {            
            var data = await Mediator.Send(query);
            return Ok(data);
        }

        public async Task<ActionResult> Post([FromBody] CreateEpisodeCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<GetEpisodeVm>> Index([FromQuery] GetEpisodeQuery query)
        {
            var data = await Mediator.Send(query);
            return Ok(data);
        }
    }
}
