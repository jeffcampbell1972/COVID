using COVID.Web.Interfaces;
using COVID.Component.Models;
using COVID.ApiClient.Interfaces;
using COVID.ApiClient.Models;
using COVID.Web.Models.ListItems;
using COVID.Web.Filters;

namespace COVID.Web.Services
{
    public class StatesPageComponentService : IComponenentService<StatesPageVM>
    {
        private readonly IApiClientService<StateSummary> _statesApiClientService;
        private readonly IStatesInfoApiClientService _statesInfoApiClientService;
        private readonly IDateHelperService _dateHelperService;

        public StatesPageComponentService(IApiClientService<StateSummary> statesApiClientService, IStatesInfoApiClientService statesInfoApiClientService, IDateHelperService dateHelperService)
        {
            _statesApiClientService = statesApiClientService;
            _statesInfoApiClientService = statesInfoApiClientService;
            _dateHelperService = dateHelperService;
        }

        public async Task<StatesPageVM> BuildAsync(ComponentBuildFilter filter)
        {
            var statesInfoData = await _statesInfoApiClientService.GetAllAsync();

            var statesInfo = statesInfoData.Select(x => new StateInfoListItem
            {
                Abbreviation = x.state,
                Name = x.name ,
                TwitterHandle = x.twitter ,
                Covid19SiteURL = x.covid19Site,
                Notes = x.notes 
            })
            .OrderBy(x => x.Name)
            .ToList();

            StateInfoListItem currState;
            if (string.IsNullOrEmpty(filter.StateAbbreviation))  // if no filter, grab first state in list
            {
                currState = statesInfo.First();
            }
            else
            { 
                currState = statesInfo.Single(x => x.Abbreviation == filter.StateAbbreviation);  
            }
            string collectionDate = "20210307";

            if (filter.CollectionDate != DateTime.MinValue)
            {
                collectionDate = _dateHelperService.UnParseDate(filter.CollectionDate);
            }

            var stateSummariesData = await _statesApiClientService.GetByDateAsync(currState.Abbreviation, collectionDate);

            var stateSummaries = new List<StateSummaryListItem>
            {
                new StateSummaryListItem
                {
                    Date = _dateHelperService.ParseDate(stateSummariesData.date) ,
                    State = stateSummariesData.state ,
                    NumTotal = stateSummariesData.total ?? 0,
                    NumPositive = stateSummariesData.positive ?? 0,
                    NumNegative = stateSummariesData.negative ?? 0,
                    Hospitalization = stateSummariesData.hospitalized ?? 0
                }
            };

            var minDate = stateSummaries.OrderBy(x => x.Date).First().Date;
            var maxDate = stateSummaries.OrderByDescending(x => x.Date).First().Date;

            var vm = new StatesPageVM
            {
                CurrState = currState,
                States = statesInfo,
                MinDate = minDate,
                MaxDate = maxDate,
                Cases = stateSummaries
            };

            return vm;
        }
    }
}
