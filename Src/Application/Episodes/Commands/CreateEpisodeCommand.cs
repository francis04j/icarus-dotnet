using MediatR;

namespace PodcastWebApi.Application.Episodes.Commands
{
    public class CreateEpisodeCommand : IRequest
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
    }
}