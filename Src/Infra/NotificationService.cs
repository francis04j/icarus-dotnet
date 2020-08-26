using System.Threading.Tasks;
using PodcastWebApi.Application.Common.Interfaces;
using PodcastWebApi.Application.Notifications.Models;

namespace Recoup.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
