using CoreTest.Models.Enums;

namespace CoreTest.Cores.Pakistan
{
    public class ClientCore : Cores.ClientCore
    {
        readonly INotificationCore _notification;
        
        public ClientCore(IClientData data, INotificationCore notification, Setup setup, ILog log) : base(data, setup, log)
        {
            _notification = notification;            
            OnAfterAddClient += ClientCore_OnAfterAddClient;
        }

        private void ClientCore_OnAfterAddClient(Models.Interfaces.IClient client)
        {
            var actions = _setup.Actions.Where(x => x.Case == Models.Enums.CaseType.AfterCreateClient)?.OrderBy(x => x.Priority).ToList();
            if (!actions?.Any() ?? true)
                return;
            foreach (var item in actions)
            {
                switch (item.Type)
                {
                    case ActionType.SendCallback: SendCallback(client); break;
                    case ActionType.SendNotification: SendNotification($"You are wizard, {client.Name}", client); break;
                }
            }
        }

        private void SendNotification(string message, IClient client)
        {
            _notification.SendNotification(message, client.Id, Models.Enums.NotificationType.SMS);
            _notification.SendNotification(message, client.Id, Models.Enums.NotificationType.Email);
            _log?.Debug($"Send notification after create client {client.Name}", client.Id);
        }

        private void SendCallback(IClient client)
        {
            _log?.Debug($"Send callback after create client {client.Name}", client.Id);
        }
    }
}
