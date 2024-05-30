using Microsoft.AspNetCore.Mvc;

namespace CoreTest.API.Pakistan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        readonly IClientCore _core;
        public ClientController(IClientCore core)
        {
            _core = core;
        }

        [HttpGet]
        public CommonResponse<Client> Get(string id)
        {
            var result = _core.GetClient(id);
            return new CommonResponse<Client>()
            {
                Success = result.Success,
                Error = result.Error,
                Message = result.Message,
                Data = result.Data as Client
            };
        }

        [HttpPost]
        public CommonResponse<Client> Post(Client client)
        {
            var result = _core.AddClient(client);
            return new CommonResponse<Client>()
            {
                Success = result.Success,
                Error = result.Error,
                Message = result.Message,
                Data = result.Data as Client
            };
        }
    }
}
