using System.Data.Entity;
using MyHomeOrg.Common.Interfaces.Repositories.User;
using MyHomeOrg.DAL.Context;
using MyHomeOrg.DAL.Repositories.User;
using Ninject.Modules;

namespace MyHomeOrg.DAL
{
    public class NInjectProfile : NinjectModule
    {
        public override void Load()
        {
            this.Bind<MyHomeOrgContext>().ToSelf();
            this.Bind<DbContext>().To<MyHomeOrgContext>();
            this.Bind<IAccountRepository>().To<AccountRepository>();
        }
    }
}