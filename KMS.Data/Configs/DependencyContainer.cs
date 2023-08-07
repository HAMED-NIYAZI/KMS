using KMS.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMS.Data.Repositories.GenericEF;
using KMS.Data.Repositories.Organization;

namespace KMS.Data.Configs
{
    public static class DependencyContainer
    {
        public static void RegisterDataLayerServices(this IServiceCollection services)
        {
            #region Services


            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped(typeof(IOrganizationRepository), typeof(OrganizationRepository));
            services.AddScoped(typeof(IGenericEFRepository<Organization>), typeof(GenericEFRepository < Organization>));

            #endregion


        }
    }
}
