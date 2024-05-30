namespace CoreTest.Interfaces
{
    public interface IClientData
    {
        public IClient? GetClient(string id);
        public CommonListResponse<IClient> GetClients(string[] id);        
        public IClient InsertClient(IClient client);
    }
}
