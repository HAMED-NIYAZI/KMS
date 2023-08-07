using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace KMS.Api.Extensions
{
 

    public static class ApiServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {

            //اضافه کردن کانتکست
            services.AddDbContext<KMSContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("KMSConnectionString"));
            });

           // services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
