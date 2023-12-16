using KMS.Data.Repositories.HomePageSetting;
using KMS.Domain.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Application.Services.LoginPageSettingService
{
    public class LoginPageSettingService : ILoginPageSettingService
    {
        private readonly IHomePageSettingRepository repository;
        public LoginPageSettingService(IHomePageSettingRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseViewModel> GetLoginPageSetting()
        {
            try
            {
                var model =await  repository.GetLoginPageSetting();

                if (model is not null)
                {
                    return new ResponseViewModel() { Data = model, Message = "داده یافت شد", StatusCode = 200, Result = Result.Success };
                }
                else {
                    return new ResponseViewModel() { Data = null, Message = "داده یافت نشد", StatusCode = 404, Result = Result.NotFound };

                }

            }
            catch (Exception ex)
            {

                return new ResponseViewModel() {Data=null,Message=ex.Message,StatusCode=500,Result=Result.ExeptionError };
            }
        }
    }
}
