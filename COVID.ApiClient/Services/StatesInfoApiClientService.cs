using COVID.ApiClient.Interfaces;
using COVID.ApiClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID.ApiClient.Services
{
    public class StatesInfoApiClientService : IStatesInfoApiClientService
    {
        public StatesInfoApiClientService() 
        {
        }

        public async Task<List<StateInfo>> GetAllAsync()
        {
            string url = "https://api.covidtracking.com/v1/states/info.json";

            try
            {
                var client = new RestClient();

                var request = new RestRequest(url);

                request.Method = Method.Get;

                var response = await client.GetAsync<List<StateInfo>>(request);

                return response;
            }
            catch (Exception ex)
            {
                // this exception should be logged
                throw;
            }
        }
    }
}
