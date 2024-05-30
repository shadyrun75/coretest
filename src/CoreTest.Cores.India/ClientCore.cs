using CoreTest.Models.Enums;

namespace CoreTest.Cores.India
{
    public class ClientCore : Cores.ClientCore
    {
        readonly INotificationCore _notification;
        
        public ClientCore(IClientData data, INotificationCore notification, Setup setup, ILog log) : base(data, setup, log)
        {
            _notification = notification;
            OnBeforeAddClient += ClientCore_OnBeforeAddClient;
            OnAfterAddClient += ClientCore_OnAfterAddClient;
        }

        private void ClientCore_OnBeforeAddClient(IClient client)
        {
            var actions = _setup.Actions.Where(x => x.Case == Models.Enums.CaseType.BeforeCreateClient)?.OrderBy(x => x.Priority).ToList();
            if (!actions?.Any() ?? true)
                return;
            foreach (var item in actions)
            {
                switch (item.Type)
                {
                    case ActionType.SendCallback: SendCallback(client, $"Before create client {client.Name}"); break;
                    default: throw new CoreTestException($"Not implemented {item.Type} in India core!");
                }
            }
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
                    case ActionType.SendCallback: SendCallback(client, $"After create client {client.Name}"); break;
                    default: throw new CoreTestException($"Not implemented {item.Type} in India core!");
                }
            }
        }

        private void SendCallback(IClient client, string message)
        {
            _log?.Debug(message, client.Id);
        }
    }
}
