using COVID.ApiClient.Interfaces;
using COVID.ApiClient.Models;
using COVID.ApiClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace COVID.Tests
{
    [TestClass]
    public sealed class UnitedStatesApiClientServiceTests
    {
        IServiceProvider _serviceProvider;
        IApiClientService<UnitedStatesSummary> _stateApiClientService;

        public UnitedStatesApiClientServiceTests()
        {
            var services = new ServiceCollection();
            services.AddScoped<IApiClientService<UnitedStatesSummary>, UnitedStatesApiClientService>();

            _serviceProvider = services.BuildServiceProvider();

            _stateApiClientService = _serviceProvider.GetService<IApiClientService<UnitedStatesSummary>>();

        }
        [TestMethod]
        public async Task GetAllAsyncTest()
        {
            try
            {
                var unitedStatesSummaries = await _stateApiClientService.GetAllAsync();

                Assert.IsNotNull(unitedStatesSummaries);
                Assert.IsTrue(unitedStatesSummaries.Count() > 0);
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
                string identifier = "az";

                var unitedStatesSummaries = await _stateApiClientService.GetHistoricAsync(identifier);

                Assert.Fail("Should raise exception.");
            }
            catch (NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public async Task GetAsyncTest()
        {
            try
            {
                string identifier = "az";

                var unitedStatesSummary = await _stateApiClientService.GetAsync(identifier);

                Assert.Fail("Should raise exception.");
            }
            catch (NotImplementedException ex)
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public async Task GetByDateAsyncTest()
        {
            try
            {
                string identifier = "us";
                string may1 = "20200501";

                var unitedStatesSummary = await _stateApiClientService.GetByDateAsync(identifier, may1);

                Assert.IsNotNull(unitedStatesSummary);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
