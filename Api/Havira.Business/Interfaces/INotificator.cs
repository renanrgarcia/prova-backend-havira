using Havira.Business.Helpers.Notification;

namespace Havira.Business.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification Notification);
        void Handle(IEnumerable<Notification> notifications);
    }
}