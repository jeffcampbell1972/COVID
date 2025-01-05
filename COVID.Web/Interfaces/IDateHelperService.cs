namespace COVID.Web.Interfaces
{
    public interface IDateHelperService
    {
        public DateTime ParseDate(int intToParse);
        public string UnParseDate(DateTime dateToParse);
    }
}
