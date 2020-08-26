using System.Threading.Tasks;
using PodcastWebApi.Application.Notifications.Models;

namespace PodcastWebApi.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
