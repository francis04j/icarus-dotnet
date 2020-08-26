using MediatR;
using System.Threading;
using PodcastWebApi.Application.Common.Interfaces;
using PodcastWebApi.Application.Notifications.Models;
using System.Threading.Tasks;

namespace PodcastWebApi.Application.Episodes.Commands
{
    public class EpisodeCreatedNotificationHandler : INotificationHandler<EpisodeCreated>
    {
            private readonly INotificationService _notification;

            public EpisodeCreatedNotificationHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(EpisodeCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }

     /*   Task INotificationHandler<EpisodeCreated>.Handle(EpisodeCreated notification, CancellationToken cancellationToken)
        {
            th
     */
    
    }
}
