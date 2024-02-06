using KMS.Domain.Dto.HomePageSettingDto;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Application.Services.LoginPageSettingService
{
    public interface ILoginPageSettingService
    {
        Task<LoginHomePageSettingDto> GetLoginPageSetting();
 

    }
}
