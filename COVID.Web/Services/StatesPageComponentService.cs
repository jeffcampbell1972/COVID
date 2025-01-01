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

        public StatesPageComponentService(IApiClientService<StateSummary> statesApiClientService, IStatesInfoApiClientService statesInfoApiClientService)
        {
            _statesApiClientService = statesApiClientService;
            _statesInfoApiClientService = statesInfoApiClientService;
        }

        public async Task<StatesPageVM> BuildAsync()
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

            var currState = statesInfo.First();
            
            var stateSummariesData = await _statesApiClientService.GetHistoricAsync(currState.Abbreviation);

            var stateSummaries = stateSummariesData.Select(x => new StateSummaryListItem
            {
                Date = ParseDate(x.date) ,
                State = x.state ,
                NumTotal = x.total ?? 0,
                NumPositive = x.positive ?? 0,
                NumNegative = x.negative ?? 0,
                Hospitalization = x.hospitalized ?? 0
            })
            .OrderByDescending(x => x.NumPositive)
            .ToList();

            var vm = new StatesPageVM
            {
                CurrState = currState,
                States = statesInfo,
                Cases = stateSummaries
            };

            return vm;
        }
        private DateTime ParseDate(int date)
        {
            string dateStr = date.ToString();

            string year = dateStr.Substring(0, 4);
            string month = dateStr.Substring(4, 2);
            string day = dateStr.Substring(6, 2);

            string dateToParse = string.Format("{0}/{1}/{2}", month, day, year);

            DateTime parsedDate = DateTime.Parse(dateToParse);

            return parsedDate;
        }
    }
}
