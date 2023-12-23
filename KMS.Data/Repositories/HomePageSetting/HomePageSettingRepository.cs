using Data.Context;
using KMS.Data.Repositories.GenericEF;
using KMS.Data.Repositories.Organization;
using KMS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Data.Repositories.HomePageSetting
{
    public class HomePageSettingRepository : GenericEFRepository<Domain.HomePageSetting>, IHomePageSettingRepository
    {
        public HomePageSettingRepository(KMSContext context) : base(context)
        {
        }

        public async Task<Domain.HomePageSetting?> GetLoginPageSetting()
        {
            var model =await GetAll().Select(m => new Domain.HomePageSetting() { 
            Title=m.Title,
            Description=m.Description,
           // OrganizationId=m.OrganizationId,
            ImagePath=m.ImagePath,
            }).FirstOrDefaultAsync();
                        
            return model;
        }
    }
}
