using CoreTest.Models.Interfaces;

namespace CoreTest.Models
{
    public class Client : IClient
    {
        public string? Id { get; set; }
        public string Name { get; set; }
    }
}
