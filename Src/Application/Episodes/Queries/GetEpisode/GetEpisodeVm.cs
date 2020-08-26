using AutoMapper;
using Domain.Entities;
using PodcastWebApi.Application.Common.Mappings;

namespace PodcastWebApi.Application.WeatherForecast.Queries.GetEpisode
{
    public class GetEpisodeVm : IMapFrom<Episode>
    {
        public string Title { get; set; }
        public string Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Episode, GetEpisodeVm>().ForMember(x => x.Id,
                opt => opt.MapFrom(ep => ep.EpisodeId));

        }
    }
}