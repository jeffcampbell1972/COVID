using COVID.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID.ApiClient.Interfaces
{
    public interface IStatesInfoApiClientService
    {
        public Task<List<StateInfo>> GetAllAsync();
    }
}
