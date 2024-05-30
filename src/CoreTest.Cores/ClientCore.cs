namespace CoreTest.Cores
{
    public class ClientCore : IClientCore
    {
        public delegate void BeforeAddClient(IClient client);
        public delegate void AfterAddClient(IClient client);
        public event BeforeAddClient? OnBeforeAddClient;
        public event AfterAddClient? OnAfterAddClient;

        protected readonly IClientData _data;
        protected readonly Setup _setup;
        protected readonly ILog? _log;

        public ClientCore(IClientData data, Setup setup, ILog? log) 
        { 
            _data = data;
            _setup = setup;
            _log = log;
        }

        public CommonResponse<IClient> AddClient(IClient value)
        {
            try
            {
                OnBeforeAddClient?.Invoke(value);
                var temp = _data.GetClient(value.Id);
                if (temp != null)
                    CoreTestException.ValueExist("Client");
                var newClient = _data.InsertClient(value);
                OnAfterAddClient?.Invoke(newClient);
                return new CommonResponse<IClient>(newClient);
            }
            catch (Exception ex)
            {
                _log?.Error("Error on add client", ex);
                throw;
            }
        }

        public CommonResponse<IClient> GetClient(string id)
        {
            try
            {
                var temp = _data.GetClient(id);
                if (temp == null)
                    CoreTestException.NotFound(id);
                return new CommonResponse<IClient>(temp);
            }
            catch (Exception ex)
            {
                _log?.Error("Error on get client", ex);
                throw;
            }
        }
    }
}
