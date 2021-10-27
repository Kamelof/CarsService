using CarsCore.Models;

namespace CarsBuisnessLayer.Interfaces
{
    public interface IAuthService
    {
        string CreateAuthToken(UserInfo userInfo);
        UserInfo GetUserInfoFromToken(string headerToken);
    }
}