using CoreTest.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.Interfaces
{
    public interface IClientCore
    {
        public CommonResponse<IClient> GetClient(string id);

        public CommonResponse<IClient> AddClient(IClient value);
    }
}