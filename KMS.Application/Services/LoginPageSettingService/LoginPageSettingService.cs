using AutoMapper;
using KMS.Application.Dtos.HomePageSettingDto;
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
        private readonly IMapper mapper;
        public LoginPageSettingService(IHomePageSettingRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<LoginHomePageSettingDto> GetLoginPageSetting()
        {
            return mapper.Map<LoginHomePageSettingDto>(await repository.GetLoginPageSetting());
        }
    }
}
