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
        private readonly ISmtpService _smtpService;

        public RegistrationService(
            IUserRepository userRepository,
            IEmailRepository emailRepository,
            IMapper mapper,
            ISmtpService smtpService)
        {
            _userRepository = userRepository;
            _emailRepository = emailRepository;
            _mapper = mapper;
            _smtpService = smtpService;
        }

        public async Task<Guid> RegisterUserAsync(AccountInfoDTO accountInfoDTO, string uri)
        {
            string confirmationString = Guid.NewGuid().ToString();
            int? emailId = !string.IsNullOrEmpty(accountInfoDTO.Email)
                ? await SaveUserEmailAsync(accountInfoDTO, confirmationString)
                : null;

            var result = await SaveUserInfoAsync(accountInfoDTO, emailId);

            if(emailId.HasValue)
            {
                await SendConfirmationEmailAsync(accountInfoDTO.Email, uri, confirmationString);
            }

            return result;
        }

        public async Task<bool> ConfirmEmailAsync(string email, string message)
        {
            string confirmationMessage = await _emailRepository.GetConfirmMessageAsync(email);
            bool result = confirmationMessage == message;

            if (result)
            {
                await _emailRepository.ConfirmEmailAsync(email);
            }

            return result;
        }
        private async Task<Guid> SaveUserInfoAsync(AccountInfoDTO accountInfoDTO, int? emailId)
        {
            var accountInfo = _mapper.Map<AccountInfo>(accountInfoDTO);
            accountInfo.EmailId = emailId.Value;

            var result = await _userRepository.AddUserAsync(accountInfo);
            return result;
        }

        private async Task SendConfirmationEmailAsync(string email, string uri, string confirmationString)
        {
            MailDTO mailDTO = new()
            {
                To = email,
                Subject = "CarService Email confirmation",
                Body = $"{uri}/accounts/" +
                $"confirm?email={email}" +
                $"&message={confirmationString}"
            };

            await _smtpService.SendMessageAsync(mailDTO);
        }

        private async Task<int> SaveUserEmailAsync(AccountInfoDTO accountInfoDTO, string confirmationString)
        {
            Email email = new()
            {
                PostName = accountInfoDTO.Email,
                IsConfirmed = false,
                ConfirmationString = confirmationString
            };

            return await _emailRepository.RegisterEmailAsync(email);
        }
    }
}
