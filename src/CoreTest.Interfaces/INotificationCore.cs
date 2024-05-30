using CoreTest.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.Interfaces
{
    public interface INotificationCore
    {
        public void SendNotification(string message, string participantId, NotificationType type);
    }
}