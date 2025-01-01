using COVID.Web.Filters;

namespace COVID.Web.Interfaces
{
    public interface IComponenentService<T>
    {
        public Task<T> BuildAsync();
    }
}
