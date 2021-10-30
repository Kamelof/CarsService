using AutoMapper;
using CarsBuisnessLayer.DTOs;
using CarsBuisnessLayer.Interfaces;
using CarsCore.Models;
using CarsDataLayer.Interfaces;
using System;
using System.Threading.Tasks;

namespace CarsBuisnessLayer.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;

        public RegistrationService(
            IUserRepository userRepository,
            IEmailRepository emailRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _emailRepository = emailRepository;
            _mapper = mapper;
        }

        public async Task<Guid> RegisterUser(AccountInfoDTO accountInfoDTO)
        {
            int? emailId = null;

            if (!string.IsNullOrEmpty(accountInfoDTO.Email))
            {
                Email email = new()
                {
                    PostName = accountInfoDTO.Email,
                    IsConfirmed = false,
                    ConfirmationString = "qwerty123qwerty"
                };

                emailId = await _emailRepository.RegisterEmailAsync(email);
            }

            AccountInfo accountInfo = _mapper.Map<AccountInfo>(accountInfoDTO);
            accountInfo.EmailId = emailId.Value;

            return await _userRepository.AddUserAsync(accountInfo);
        }
    }
}
