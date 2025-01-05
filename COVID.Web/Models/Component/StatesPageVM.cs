using COVID.ApiClient.Models;
using COVID.Web.Models.ListItems;

namespace COVID.Component.Models
{
    public class StatesPageVM
    {
        public List<StateInfoListItem> States { get; set; }
        public StateInfoListItem CurrState { get; set; }
        public List<StateSummaryListItem> Cases { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
    }
}
