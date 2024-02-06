using KMS.Api.Controllers;
using KMS.Domain.Dto.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KMS.API.Controllers
{
    public class AccountController : KmsBaseController
    {


        //[HttpPost("Login")]
        //public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        ////{
        ////    try
        ////    {
        ////        //Log
        ////        // Log(userLoginDto);

        ////        //validation

        ////        //Login
        ////        userLoginDto.Password = HashPassword.MD5Hash(userLoginDto.Password);

        ////        var loginUser = userService.Login(user);

        ////        if (loginUser is null) return NotFound();

        ////        string token = tokenService.CreateToken(loginUser);

        ////        return Ok(new { token });
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        // Logex(ex.Message);
        ////        // return BadRequest();
        ////        return Content(ex.Message + "\n" + ex.InnerException.Message + "\n" + ex.InnerException.StackTrace);
        ////    }

        //}

    }
}
