using COVID.Web.Interfaces;

namespace COVID.Web.Services.Helper
{
    public class DateHelperService : IDateHelperService
    {
        public DateTime ParseDate(int date)
        {
            string dateStr = date.ToString();

            string year = dateStr.Substring(0, 4);
            string month = dateStr.Substring(4, 2);
            string day = dateStr.Substring(6, 2);

            string dateToParse = string.Format("{0}/{1}/{2}", month, day, year);

            DateTime parsedDate = DateTime.Parse(dateToParse);

            return parsedDate;
        }
        public string UnParseDate(DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString("D2");
            string day = date.Day.ToString("D2");

            return string.Format("{0}{1}{2}", year, month, day);
        }
    }
}
