using KMS.Application.Services.AccountService;
using KMS.Application.Services.LoginPageSettingService;
using KMS.Application.Services.OrganizationService;
using KMS.Application.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace KMS.Application.RegisterService;

public static class DependencyContainer
{
    public static void RegisterApplicationLayerServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IOrganizationService, OrganizationService>();
        services.AddScoped<ILoginPageSettingService, LoginPageSettingService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IUserService, UserService>();

    }
}
