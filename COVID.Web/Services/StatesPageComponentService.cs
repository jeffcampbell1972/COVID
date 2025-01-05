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
                collectionDate = UnParseDate(filter.CollectionDate);
            }

            var stateSummariesData = await _statesApiClientService.GetByDateAsync(currState.Abbreviation, collectionDate);

            var stateSummaries = new List<StateSummaryListItem>
            {
                new StateSummaryListItem
                {
                    Date = ParseDate(stateSummariesData.date) ,
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
        private string UnParseDate(DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString("D2");
            string day = date.Day.ToString("D2");

            return string.Format("{0}{1}{2}", year, month, day);
        }
    }
}
