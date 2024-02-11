using KMS.Api.Controllers;
using KMS.Application.Services.LoginPageSettingService;
using KMS.Application.Services.OrganizationService;
using KMS.Domain.Dto.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KMS.API.Controllers
{

    public class HomeController : KmsBaseController
    {
        private readonly ILoginPageSettingService loginPageSettingService;
        private readonly IConfiguration configuration;

        public HomeController(ILoginPageSettingService loginPageSettingService, IConfiguration configuration)
        {
            this.loginPageSettingService = loginPageSettingService;
            this.configuration = configuration;
        }

        [HttpGet("GetLoginPageSetting")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLoginPageSetting()
        {
            try
            {
                var res = await loginPageSettingService.GetLoginPageSetting();
                if (res == null)
                {
                    return Ok(ApiResponse.Response(res));
                }
                res.ImagePath=(res.ImagePath == string.Empty || res.ImagePath == null) ? string.Empty : configuration["HomePageSettingLogo"] + res.ImagePath;
                //res.ImagePath = configuration["HomePageSettingLogo"] + res.ImagePath;
                return Ok(ApiResponse.Response(res));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }
    }
}
