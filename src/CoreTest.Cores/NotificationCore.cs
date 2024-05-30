using CoreTest.Models.Enums;

namespace CoreTest.Cores
{
    public class NotificationCore : INotificationCore
    {
        protected readonly ILog? _log;
        public NotificationCore(ILog log) 
        {
            _log = log;
        }
        public void SendNotification(string message, string participantId, NotificationType type)
        {
            _log?.Attention(message, $"{participantId} {type}");
        }
    }
}
