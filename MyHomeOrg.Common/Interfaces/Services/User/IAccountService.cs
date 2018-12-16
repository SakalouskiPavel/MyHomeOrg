using System.Threading.Tasks;
using MyHomeOrg.Common.DTO.User;

namespace MyHomeOrg.Common.Interfaces.Services.User
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterUserDto registerData);

        Task<LoginDto> FindUserAsync(string userName, string password);
    }
}