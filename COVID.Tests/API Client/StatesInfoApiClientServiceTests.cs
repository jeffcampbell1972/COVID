using COVID.ApiClient.Interfaces;
using COVID.ApiClient.Models;
using COVID.ApiClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace COVID.Tests
{
    [TestClass]
    public sealed class StatesInfoApiClientServiceTests
    {
        IServiceProvider _serviceProvider;
        IStatesInfoApiClientService _statesInfoApiClientService;

        public StatesInfoApiClientServiceTests()
        {
            var services = new ServiceCollection();
            services.AddScoped<IStatesInfoApiClientService, StatesInfoApiClientService>();

            _serviceProvider = services.BuildServiceProvider();

            _statesInfoApiClientService = _serviceProvider.GetService<IStatesInfoApiClientService>();

        }
        [TestMethod]
        public async Task GetAllAsyncTest()
        {
            try
            {
                var stateInfoRecords = await _statesInfoApiClientService.GetAllAsync();

                Assert.IsNotNull(stateInfoRecords);
                Assert.IsTrue(stateInfoRecords.Count() == 56);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
