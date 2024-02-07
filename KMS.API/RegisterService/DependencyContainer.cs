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
using KMS.API.Services.JwtToken;

namespace KMS.API.RegisterService;

public static class DependencyContainer
{
    public static void RegisterKMSAPIServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
    }
}
