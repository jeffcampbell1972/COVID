﻿using COVID.ApiClient.Interfaces;
using COVID.ApiClient.Models;
using COVID.ApiClient.Services;
using COVID.Component.Models;
using COVID.Web.Interfaces;
using COVID.Web.Services;
using Microsoft.Extensions.DependencyInjection;

namespace COVID.Component.Tests
{
    [TestClass]
    public sealed class CasesPageComponenetServiceTest
    {
        IServiceProvider _serviceProvider;
        IComponenentService<CasesPageVM> _casesPageComponentService;

        public CasesPageComponenetServiceTest()
        {
            var services = new ServiceCollection();
            services.AddScoped<IApiClientService<StateSummary>, StatesApiClientService>();
            services.AddScoped<IComponenentService<CasesPageVM>, CasesPageComponentService>();

            _serviceProvider = services.BuildServiceProvider();

            _casesPageComponentService = _serviceProvider.GetService<IComponenentService<CasesPageVM>>();

        }

        [TestMethod]
        public async Task BuildAsyncTest()
        {
            try
            {
                var vm = await _casesPageComponentService.BuildAsync();

                Assert.IsNotNull(vm);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
