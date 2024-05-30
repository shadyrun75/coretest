using CoreTest.Interfaces;
using CoreTest.Models.Common;
using CoreTest.Models.Interfaces;

namespace CoreTest.Data.Pakistan
{
    public class ClientData : IClientData
    {
        List<IClient> _clients = new List<IClient>();
        public IClient? GetClient(string id)
        {
            return _clients.FirstOrDefault(x => x.Id == id);
        }

        public CommonListResponse<IClient> GetClients(string[] id)
        {
            var temp = _clients.Where(x => id.Contains(x.Id)).ToList();
            return new CommonListResponse<IClient>(temp);
        }

        public IClient InsertClient(IClient client)
        {
            if (String.IsNullOrEmpty(client.Id))
                client.Id = Guid.NewGuid().ToString();
            _clients.Add(client);
            return client;
        }
    }
}
