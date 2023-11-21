using KMS.Api.Controllers;
using KMS.Application.Services.LoginPageSettingService;
using KMS.Application.Services.OrganizationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KMS.API.Controllers
{
 
    public class HomeController : KmsBaseController
    {
        private readonly ILoginPageSettingService loginPageSettingService;

        public HomeController(ILoginPageSettingService loginPageSettingService)
        {
            this.loginPageSettingService = loginPageSettingService;
        }
        [HttpGet("GetLoginPageSetting")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLoginPageSetting()
        {
           var res=await loginPageSettingService.GetLoginPageSetting();
            return Ok(res);
        }
    }
}
