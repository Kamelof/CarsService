using CarsBuisnessLayer.DTOs;
using System;
using System.Threading.Tasks;

namespace CarsBuisnessLayer.Interfaces
{
    public interface IRegistrationService
    {
        Task<Guid> RegisterUserAsync(AccountInfoDTO accountInfoDTO, string uri);
        Task<bool> ConfirmEmailAsync(string email, string message);
    }
}