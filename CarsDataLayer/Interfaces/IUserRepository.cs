using CarsCore.Models;
using System;
using System.Threading.Tasks;

namespace CarsDataLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo);
        Task UpdatePasswordAsync(LoginInfo loginInfo);
        Task<bool> VerifyLoginInfoAsync(LoginInfo loginInfo);
        Task<Guid> AddUserAsync(AccountInfo accountInfo);
    }
}
