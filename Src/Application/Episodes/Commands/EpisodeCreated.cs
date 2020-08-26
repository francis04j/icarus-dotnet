using MediatR;

namespace PodcastWebApi.Application.Episodes.Commands
{
    public class EpisodeCreated : INotification
    {
        public string EpisodeId { get; set; }

    }
}
