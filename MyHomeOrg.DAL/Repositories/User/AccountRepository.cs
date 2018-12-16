using System.Data.Entity;
using MyHomeOrg.Common.DbModels.User;
using MyHomeOrg.Common.Interfaces.Repositories.User;

namespace MyHomeOrg.DAL.Repositories.User
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(DbContext context) : base(context)
        {
        }
    }
}