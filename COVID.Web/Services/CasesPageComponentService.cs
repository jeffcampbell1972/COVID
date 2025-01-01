using COVID.Web.Interfaces;
using COVID.Component.Models;
using COVID.ApiClient.Interfaces;
using COVID.ApiClient.Models;
using COVID.Web.Models.ListItems;

namespace COVID.Web.Services
{
    public class CasesPageComponentService : IComponenentService<CasesPageVM>
    {
        private readonly IApiClientService<StateSummary> _statesApiClientService;

        public CasesPageComponentService(IApiClientService<StateSummary> statesApiClientService)
        {
            _statesApiClientService = statesApiClientService;
        }

        public async Task<CasesPageVM> BuildAsync()
        {
            var stateSummaries = await _statesApiClientService.GetAllAsync();

            var listItems = stateSummaries.Select(x => new StateSummaryListItem
            {
                Date = ParseDate(x.date) ,
                State = x.state ,
                NumTotal = x.total ?? 0,
                NumPositive = x.positive ?? 0,
                NumNegative = x.negative ?? 0,
                Hospitalization = x.hospitalized ?? 0
            })
            .OrderByDescending(x => x.NumTotal)
            .ToList();

            var vm = new CasesPageVM
            {
                States = listItems
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
