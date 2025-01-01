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
    public class StatesApiClientService : IApiClientService<StateSummary>
    {
        public StatesApiClientService() 
        {
        }

        public async Task<StateSummary> GetAsync(string stateAbbreviation)
        {
            string url = string.Format("https://api.covidtracking.com/v1/states/{0}/current.json", stateAbbreviation);

            try
            {
                var client = new RestClient();

                var request = new RestRequest(url);

                request.Method = Method.Get;

                var response = await client.GetAsync<StateSummary>(request);

                return response;
            }
            catch (Exception ex)
            {
                // this exception should be logged
                throw;
            }
        }
        public async Task<StateSummary> GetByDateAsync(string stateAbbreviation, string date)
        {
            
            string url = string.Format("https://api.covidtracking.com/v1/states/{0}/{1}.json", stateAbbreviation, date);

            try
            {
                var client = new RestClient();

                var request = new RestRequest(url);

                request.Method = Method.Get;

                var response = await client.GetAsync<StateSummary>(request);

                return response;
            }
            catch (Exception ex)
            {
                // this exception should be logged
                throw;
            }

        }
        public async Task<List<StateSummary>> GetHistoricAsync(string stateAbbreviation)
        {
            string url = string.Format("https://api.covidtracking.com/v1/states/{0}/daily.json", stateAbbreviation);

            try
            {
                var client = new RestClient();

                var request = new RestRequest(url);

                request.Method = Method.Get;

                var response = await client.GetAsync<List<StateSummary>>(request);

                return response;
            }
            catch (Exception ex)
            {
                // this exception should be logged
                throw;
            }
        }
        public async Task<List<StateSummary>> GetAllAsync()
        {
            string url = "https://api.covidtracking.com/v1/states/daily.json";

            try
            {
                var client = new RestClient();

                var request = new RestRequest(url);

                request.Method = Method.Get;

                var response = await client.GetAsync<List<StateSummary>>(request);

                return response;
            }
            catch (Exception ex)
            {
                // this exception should be logged
                throw;
            }
        }
        public async Task<List<StateSummary>> GetCurrentAsync()
        {
            string url = "https://api.covidtracking.com/v1/states/current.json";

            try
            {
                var client = new RestClient();

                var request = new RestRequest(url);

                request.Method = Method.Get;

                var response = await client.GetAsync<List<StateSummary>>(request);

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
