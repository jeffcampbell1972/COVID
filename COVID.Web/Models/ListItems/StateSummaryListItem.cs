namespace COVID.Web.Models.ListItems
{
    public class StateSummaryListItem
    {
        public DateTime Date { get; set; }
        public string State { get; set; }
        public int NumTotal { get; set; }
        public int NumPositive { get; set; }
        public int NumNegative { get; set; }
        public int Hospitalization { get; set; }
    }
}
