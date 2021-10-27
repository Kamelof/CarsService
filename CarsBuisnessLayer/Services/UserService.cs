using CarsBuisnessLayer.Interfaces;
using CarsCore.Models;
using CarsDataLayer.Interfaces;
using System.Threading.Tasks;

namespace CarsBuisnessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashService _hashService;

        public UserService(
            IUserRepository userRepository,
            IHashService hashService)
        {
            _userRepository = userRepository;
            _hashService = hashService;
        }

        public async Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo)
        {
            LoginInfo hashedLoginInfo = new()
            {
                Login = loginInfo.Login,
                Password = _hashService.HashString(loginInfo.Password)
            };

            return await _userRepository.GetRoleByLoginInfoAsync(hashedLoginInfo);
        }

        public async Task UpdatePasswordAsync(LoginInfo loginInfo)
        {
            loginInfo.Password = _hashService.HashString(loginInfo.Password);

            await _userRepository.UpdatePasswordAsync(loginInfo);
        }

        public async Task<bool> VerifyPasswordAsync(LoginInfo loginInfo)
        {
            loginInfo.Password = _hashService.HashString(loginInfo.Password);

            return await _userRepository.VerifyLoginInfoAsync(loginInfo);
        }
    }
}