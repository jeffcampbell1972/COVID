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
    public class UnitedStatesApiClientService : IApiClientService<UnitedStatesSummary>
    {
        public UnitedStatesApiClientService() 
        {
        }

        public async Task<UnitedStatesSummary> GetAsync(string stateAbbreviation)
        {
            throw new NotImplementedException("Not relvant for United States-level calls.");
        }
        public async Task<UnitedStatesSummary> GetByDateAsync(string identifier, string date)
        {
            
            string url = string.Format(" https://api.covidtracking.com/v1/{0}/{1}.json", identifier, date);

            try
            {
                var client = new RestClient("https://api.covidtracking.com/v1/");
                
                var request = new RestRequest(url);

                request.Method = Method.Get;

                var response = await client.GetAsync<UnitedStatesSummary>(request);

                return response;
            }
            catch (Exception ex)
            {
                // this exception should be logged
                throw;
            }

        }
        public async Task<List<UnitedStatesSummary>> GetHistoricAsync(string stateAbbreviation)
        {

            throw new NotImplementedException("Not relvant for United States-level calls.");
        }
        public async Task<List<UnitedStatesSummary>> GetAllAsync()
        {
            string url = "https://api.covidtracking.com/v1/us/daily.json";

            try
            {
                var client = new RestClient();

                var request = new RestRequest(url);

                request.Method = Method.Get;

                var response = await client.GetAsync<List<UnitedStatesSummary>>(request);

                return response;
            }
            catch (Exception ex)
            {
                // this exception should be logged
                throw;
            }
        }
        public async Task<List<UnitedStatesSummary>> GetCurrentAsync()
        {
            string url = "https://api.covidtracking.com/v1/us/current.json";

            try
            {
                var client = new RestClient();

                var request = new RestRequest(url);

                request.Method = Method.Get;

                var response = await client.GetAsync<List<UnitedStatesSummary>>(request);

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
