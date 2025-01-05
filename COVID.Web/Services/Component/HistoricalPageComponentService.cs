using COVID.Web.Interfaces;
using COVID.Component.Models;
using COVID.ApiClient.Interfaces;
using COVID.ApiClient.Models;
using COVID.Web.Models.ListItems;
using COVID.Web.Filters;

namespace COVID.Web.Services
{
    public class HistoricalPageComponentService : IComponenentService<HistoricalPageVM>
    {
        private readonly IApiClientService<StateSummary> _statesApiClientService;
        private readonly IDateHelperService _dateHelperService;

        public HistoricalPageComponentService(IApiClientService<StateSummary> statesApiClientService, IDateHelperService dateHelperService)
        {
            _statesApiClientService = statesApiClientService;
            _dateHelperService = dateHelperService;
        }

        public async Task<HistoricalPageVM> BuildAsync(ComponentBuildFilter filter)
        {
            var stateSummaries = await _statesApiClientService.GetAllAsync();

            var listItems = stateSummaries.Select(x => new StateSummaryListItem
            {
                Date = _dateHelperService.ParseDate(x.date) ,
                State = x.state ,
                NumTotal = x.total ?? 0,
                NumPositive = x.positive ?? 0,
                NumNegative = x.negative ?? 0,
                Hospitalization = x.hospitalized ?? 0
            })
            .OrderByDescending(x => x.NumPositive)
            .ToList();

            var vm = new HistoricalPageVM
            {
                Cases = listItems
            };

            return vm;
        }
    }
}
