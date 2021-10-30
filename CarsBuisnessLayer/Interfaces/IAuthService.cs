using CarsCore.Models;

namespace CarsBuisnessLayer.Interfaces
{
    public interface IAuthService
    {
        string CreateAuthToken(UserInfo userInfo);
        string GetUserLoginFromToken(string headerToken);
    }
}