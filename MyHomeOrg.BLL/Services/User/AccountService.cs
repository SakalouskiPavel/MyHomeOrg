using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyHomeOrg.Common.DbModels.User;
using MyHomeOrg.Common.DTO.User;
using MyHomeOrg.Common.Interfaces.Repositories.User;
using MyHomeOrg.Common.Interfaces.Services.User;

namespace MyHomeOrg.BLL.Services.User
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            this._repository = repository;
        }

        public async Task RegisterAsync(RegisterUserDto registerData)
        {
            var mappedEntity = Mapper.Map<Account>(registerData);
            await this._repository.AddAsync(mappedEntity);
        }

        public async Task<LoginDto> FindUserAsync(string userName, string password)
        {
            var entity = (await this._repository.Find(account => account.Username == userName && account.Password == password)).FirstOrDefault();

            return Mapper.Map<LoginDto>(entity);
        }
    }
}