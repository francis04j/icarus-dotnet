using System.Collections.Generic;
using MediatR;

namespace PodcastWebApi.Application.WeatherForecast.Queries.GetEpisode
{
    public class GetEpisodeQuery: IRequest<IEnumerable<GetEpisodeVm>>
    {
        public int Limit { get; set; } = 0;
        // public string CreatedAtBefore { get; set; }
        // public string CreatedAfter { get; set; }
        // public string Topic { get; set; }
        // public string Search { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

    }
}