using COVID.Web.Interfaces;
using COVID.Component.Models;

namespace COVID.Web.Services
{
    public class CasesPageComponentService : IComponenentService<CasesPageVM>
    {
        public async Task<CasesPageVM> BuildAsync()
        {
            var vm = new CasesPageVM
            {
                IsLoaded = true
            };

            return vm;
        }
    }
}
