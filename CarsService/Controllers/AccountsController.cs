using CarsBuisnessLayer.DTOs;
using CarsBuisnessLayer.Interfaces;
using CarsCore.Models;
using CarsCore.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsPresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ILogger<AccountsController> _logger;
        private readonly IRegistrationService _registrationService;

        public AccountsController(
            IAuthService authService,
            IUserService userService,
            ILogger<AccountsController> logger,
            IRegistrationService registrationService)
        {
            _authService = authService;
            _userService = userService;
            _logger = logger;
            _registrationService = registrationService;
        }

        [HttpPost("manager")]
        public async Task<IActionResult> CreateManager(AccountInfo accountInfo)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("mark_obsolete")]
        public async Task<IActionResult> MarkAccountsPasswordObsolete(List<Guid> accountsIds)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [Authorize(Roles = nameof(Role.Admin))]
        [HttpPut("password")]
        public async Task<IActionResult> UpdatePassword(PasswordChangeRequest request)
        {
            string authHeader = Request.Headers["Authorization"][0];

            string userLogin = _authService.GetUserLoginFromToken(authHeader);

            LoginInfo loginInfo = new()
            {
                Login = userLogin,
                Password = request.OldPassword
            };

            if (await _userService.VerifyPasswordAsync(loginInfo))
            {
                loginInfo.Password = request.NewPassword;
                await _userService.UpdatePasswordAsync(loginInfo);

                return Ok("Password updated!");
            }

            return BadRequest("Invalid login or password!");
        }

        [HttpPut("info")]
        public async Task<IActionResult> UpdateInfo(AccountInfo accountInfo)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginInfo loginInfo)
        {
            Role? userRole = await _userService.GetRoleByLoginInfoAsync(loginInfo);
            if (userRole != null)
            {
                string token = _authService.CreateAuthToken(
                    new UserInfo
                    {
                        Login = loginInfo.Login,
                        Role = userRole.Value
                    });

                return Ok(token);
            }

            return BadRequest("Invalid username or password.");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountInfoDTO accountInfoDTO)
        {
            return Ok(await _registrationService.RegisterUserAsync(accountInfoDTO, Request.Scheme + "://" + Request.Host));
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmUserEmail(string email, string message)
        {
            return Ok(await _registrationService.ConfirmEmailAsync(email, message));
        }
    }
}
