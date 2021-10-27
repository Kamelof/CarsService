using CarsCore.Models;
using System.Threading.Tasks;

namespace CarsBuisnessLayer.Interfaces
{
    public interface IUserService
    {
        Task UpdatePasswordAsync(LoginInfo loginInfo);
        Task<bool> VerifyPasswordAsync(LoginInfo loginInfo);
        Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo);
    }
}
