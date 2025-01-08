using Havira.Business.Interfaces;

namespace Havira.Business.Helpers.Notification
{
    public class Notificator : INotificator
    {
        private readonly List<Notification> _notifications;

        public Notificator()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification Notification)
        {
            _notifications.Add(Notification);
        }

        public void Handle(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}