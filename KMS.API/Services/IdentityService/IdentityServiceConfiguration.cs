using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace KMS.API.Services.IdentityService;

public static class IdentityServiceConfiguration
{
 
     public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
    {


        //tokenValidation
        
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                //برای کنترل زمان توکن
                ClockSkew = TimeSpan.FromMinutes(int.Parse(configuration["TimeOuToken"])),
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

 


        return services;

    }


    //public static bool ValidateToken(string token)
    //{
    //    try
    //    {
    //        var validationParameters = new TokenValidationParameters
    //        {
    //            //برای کنترل زمان توکن
    //            // ClockSkew = TimeSpan.FromMinutes(int.Parse(StaticVariables.TimeOuToken)),
    //            ValidateLifetime = true,
    //            ValidateIssuerSigningKey = true,
    //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
    //            ValidateIssuer = false,
    //            ValidateAudience = false
    //        };


    //        var tokenHandler = new JwtSecurityTokenHandler();
    //        tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
    //        var jwt = (JwtSecurityToken)validatedToken;

    //        return true;
    //    }
    //    catch (Exception)
    //    {
    //        return false;
    //    }
    //}



    public static string? GetJWTTokenClaim(string token, string claimName)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            var claimValue = securityToken.Claims.FirstOrDefault(c => c.Type == claimName)?.Value;
            return claimValue;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
