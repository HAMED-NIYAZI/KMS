using KMS.Domain.ViewModel.LoginPage;
using KMS.Domain.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Application.Services.LoginPageSettingService
{
    public interface ILoginPageSettingService
    {
        Task<ResponseViewModel> GetLoginPageSetting();
 

    }
}
