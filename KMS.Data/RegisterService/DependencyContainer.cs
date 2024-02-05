using KMS.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMS.Data.Repositories.GenericEF;
using KMS.Data.Repositories.Organization;
using KMS.Data.Repositories.HomePageSetting;

namespace KMS.Data.RegisterService;

public static class DependencyContainer
{
    public static void RegisterDataLayerServices(this IServiceCollection services)
    {
        #region Repository


        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        services.AddScoped(typeof(IOrganizationRepository), typeof(OrganizationRepository));
        services.AddScoped(typeof(IGenericEFRepository<Organization>), typeof(GenericEFRepository < Organization>));
        services.AddScoped<IHomePageSettingRepository, HomePageSettingRepository>();

        #endregion


    }
}
