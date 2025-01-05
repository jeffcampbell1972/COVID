using COVID.ApiClient.Interfaces;
using COVID.ApiClient.Models;
using COVID.ApiClient.Services;
using COVID.Component.Models;
using COVID.Web.Filters;
using COVID.Web.Interfaces;
using COVID.Web.Services;
using Microsoft.Extensions.DependencyInjection;

namespace COVID.Component.Tests
{
    [TestClass]
    public sealed class CasesPageComponenetServiceTest
    {
        IServiceProvider _serviceProvider;
        IComponenentService<HistoricalPageVM> _casesPageComponentService;

        public CasesPageComponenetServiceTest()
        {
            var services = new ServiceCollection();
            services.AddScoped<IApiClientService<StateSummary>, StatesApiClientService>();
            services.AddScoped<IComponenentService<HistoricalPageVM>, HistoricalPageComponentService>();

            _serviceProvider = services.BuildServiceProvider();

            _casesPageComponentService = _serviceProvider.GetService<IComponenentService<HistoricalPageVM>>();

        }

        [TestMethod]
        public async Task BuildAsyncTest()
        {
            try
            {
                ComponentBuildFilter filter = new ComponentBuildFilter();
                var vm = await _casesPageComponentService.BuildAsync(filter);

                Assert.IsNotNull(vm);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
