using MyHomeOrg.BLL.Services.User;
using MyHomeOrg.Common.Interfaces.Services.User;
using Ninject.Modules;

namespace MyHomeOrg.BLL
{
    public class NInjectProfile: NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAccountService>().To<AccountService>();
        }
    }
}