using KMS.Api.Controllers;
using KMS.API.Services.JwtToken;
using KMS.Application.Services.AccountService;
using KMS.Application.Services.LoginPageSettingService;
using KMS.Common.Tools.Security;
using KMS.Domain.Dto.Account;
using KMS.Domain.Dto.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KMS.API.Controllers
{
    public class AccountController : KmsBaseController
    {
        private readonly IAccountService accountService;
        private readonly ITokenService tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            this.accountService = accountService;
            this.tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            try
            {
                //Log
                // Log(userLoginDto);

                //validation

                //Login
                userLoginDto.Password = HashPassword.MD5Hash(userLoginDto.Password);

                var loginUser = accountService.Login(userLoginDto);

                if (loginUser == null) return Ok(ApiResponse.Response(loginUser)); 
                //throw new Exception("نام کاربری یا کلمه عبور اشتباه است");

                loginUser.Token = tokenService.CreateToken(loginUser);

  
                 return Ok(ApiResponse.Response(loginUser));

            }
            catch (Exception ex)
            {
                 return Ok(ApiResponse.Response(ex.Message));
            }
        }
    }
}
