using COVID.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID.ApiClient.Interfaces
{
    // a generic interface was created for demonstration purposes.  It probably makes more sense to have separate interfaces for state data vs us data.
    public interface IApiClientService<T>
    {
        public Task<T> GetAsync(string identifier);
        public Task<T> GetByDateAsync(string identifier, string date);
        public Task<List<T>> GetHistoricAsync(string identifier);
        public Task<List<T>> GetAllAsync();
        public Task<List<T>> GetCurrentAsync();
    }
}
