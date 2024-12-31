using COVID.ApiClient.Interfaces;
using COVID.ApiClient.Models;
using COVID.ApiClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace COVID.Tests
{
    [TestClass]
    public sealed class StatesApiClientServiceTests
    {
        IServiceProvider _serviceProvider;
        IApiClientService<StateSummary> _stateApiClientService;

        public StatesApiClientServiceTests()
        {
            var services = new ServiceCollection();
            services.AddScoped<IApiClientService<StateSummary>, StatesApiClientService>();

            _serviceProvider = services.BuildServiceProvider();

            _stateApiClientService = _serviceProvider.GetService<IApiClientService<StateSummary>>();

        }
        [TestMethod]
        public async Task GetAllAsyncTest()
        {
            try
            {
                var statesummaries = await _stateApiClientService.GetAllAsync();

                Assert.IsNotNull(statesummaries);
                Assert.IsTrue(statesummaries.Count() == 56);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [TestMethod]
        public async Task GetHistoricAsyncTest()
        {
            try
            {
                string arizona = "az";

                var statesummaries = await _stateApiClientService.GetHistoricAsync(arizona);

                Assert.IsNotNull(statesummaries);
                Assert.IsTrue(statesummaries.Count() > 0);  
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [TestMethod]
        public async Task GetAsyncTest()
        {
            try
            {
                string arizona = "az";

                var statesummary = await _stateApiClientService.GetAsync(arizona);

                Assert.IsNotNull(statesummary);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [TestMethod]
        public async Task GetByDateAsyncTest()
        {
            try
            {
                string arizona = "az";
                string may1 = "20200501";

                var statesummary = await _stateApiClientService.GetByDateAsync(arizona, may1);

                Assert.IsNotNull(statesummary);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
