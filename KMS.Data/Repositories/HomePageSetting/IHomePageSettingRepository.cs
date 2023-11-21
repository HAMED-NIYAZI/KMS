using KMS.Domain;
using KMS.Domain.ViewModel.LoginPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Data.Repositories.HomePageSetting
{
    public interface IHomePageSettingRepository
    {
        Task<LoginPageViewModel?> GetLoginPageSetting();
    }
}
