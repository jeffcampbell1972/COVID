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
        IApiClientService<UnitedStatesSummary> _unitedStatesApiClientService;

        public UnitedStatesApiClientServiceTests()
        {
            var services = new ServiceCollection();
            services.AddScoped<IApiClientService<UnitedStatesSummary>, UnitedStatesApiClientService>();

            _serviceProvider = services.BuildServiceProvider();

            _unitedStatesApiClientService = _serviceProvider.GetService<IApiClientService<UnitedStatesSummary>>();

        }
        [TestMethod]
        public async Task GetAllAsyncTest()
        {
            try
            {
                var unitedStatesSummaries = await _unitedStatesApiClientService.GetAllAsync();

                Assert.IsNotNull(unitedStatesSummaries);
                Assert.IsTrue(unitedStatesSummaries.Count() > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [TestMethod]
        public async Task GetCurrentAsyncTest()
        {
            try
            {
                var unitedStatesSummaries = await _unitedStatesApiClientService.GetCurrentAsync();

                Assert.IsNotNull(unitedStatesSummaries);
                Assert.IsTrue(unitedStatesSummaries.Count() == 1);
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

                var unitedStatesSummaries = await _unitedStatesApiClientService.GetHistoricAsync(identifier);

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

                var unitedStatesSummary = await _unitedStatesApiClientService.GetAsync(identifier);

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

                var unitedStatesSummary = await _unitedStatesApiClientService.GetByDateAsync(identifier, may1);

                Assert.IsNotNull(unitedStatesSummary);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
