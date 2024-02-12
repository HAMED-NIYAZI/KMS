using KMS.Api.Controllers;
using KMS.API.Services.JwtToken;
using KMS.Application.Services.AccountService;
using KMS.Application.Services.LoginPageSettingService;
using KMS.Application.Services.UserService;
using KMS.Common.Tools.Security;
using KMS.Data.Repositories.User;
using KMS.Domain.Dto.Account;
using KMS.Domain.Dto.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KMS.API.Controllers
{
    public class AccountController : KmsBaseController
    {
        private readonly IAccountService accountService;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;
        private readonly IUserService userService;

        public AccountController(IAccountService accountService, ITokenService tokenService, IConfiguration configuration, IUserService userService)
        {
            this.accountService = accountService;
            this.tokenService = tokenService;
            this.configuration = configuration;
            this.userService = userService;
        }


        [AllowAnonymous]
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
                loginUser.ImagePath = (loginUser.ImagePath == string.Empty || loginUser.ImagePath == null) ? string.Empty : configuration["UserAvatar"] + loginUser.ImagePath;

                loginUser.Token = tokenService.CreateToken(loginUser);


                return Ok(ApiResponse.Response(loginUser));

            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }

        [AllowAnonymous]
        [HttpPost("RequestRegister")]
        public async Task<IActionResult> RequestRegister(RequestRegisterDto model)
        {
            try
            {
                //Log
                // Log(userLoginDto);

                //validation

                model.Password = HashPassword.MD5Hash(model.Password);

                userService.RequestRegister(model);

                return Ok(ApiResponse.Response(new { Result = Result.Success, Message = "درخواست عضویت شما با موفقیت ثبت شد" }));

            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }

    }
}
