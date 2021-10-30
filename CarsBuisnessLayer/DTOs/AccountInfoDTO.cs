using CarsCore.Models;

namespace CarsBuisnessLayer.DTOs
{
    public class AccountInfoDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public LoginInfo LoginInfo { get; set; }
        public string Email { get; set; }
    }
}
