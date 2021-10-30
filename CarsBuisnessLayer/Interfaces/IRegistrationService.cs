using CarsBuisnessLayer.DTOs;
using System;
using System.Threading.Tasks;

namespace CarsBuisnessLayer.Interfaces
{
    public interface IRegistrationService
    {
        Task<Guid> RegisterUser(AccountInfoDTO accountInfoDTO);
    }
}