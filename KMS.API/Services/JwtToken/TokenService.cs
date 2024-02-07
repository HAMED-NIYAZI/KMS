using KMS.Domain.Dto.Account;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KMS.API.Services.JwtToken;

public class TokenService : ITokenService
{
    private readonly IConfiguration configuration;
    private readonly string tokenKey;
    private readonly string timeOuToken;
    public TokenService(IConfiguration configuration)
    {

        this.configuration = configuration;
        this.tokenKey = configuration["TokenKey"];
        this.timeOuToken = configuration["TimeOuToken"];

    }
    public string CreateToken(UserLoginReturnDto user)
    {
        var claim = new List<Claim> //لیستی از کلایم ها ست کردیم
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
               // new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.NameId,user.UserName)
            };


        var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

        //با کی ای و الگوریتم  مربوطه یک کردنشیال ساختیم
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        //یک سکیوریتی توکن دیسکریپتور ساختیم
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claim), //کلایم را به موضوع زدیم
            Expires = DateTime.Now.AddMinutes(int.Parse(timeOuToken)),//تعداد روز های اعتبار توکن
            SigningCredentials = creds //کردنشیال بالا را در ساین این کردنشیال زدیم
        };
        var tokenHandler = new JwtSecurityTokenHandler();//یک توکن هندلر ساختیم
        var token = tokenHandler.CreateToken(tokenDescriptor);// توکن را می سازیم

        return tokenHandler.WriteToken(token);//با استفاده ار توکن هندلر توکن جدید را نوشته و برمیگردانیم

    }

    public string CreateToken(int userId)
    {
        var claim = new List<Claim> //لیستی از کلایم ها ست کردیم
            {
                new Claim(ClaimTypes.NameIdentifier,userId.ToString()),
               // new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.NameId,user.UserName)
            };


        var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

        //با کی ای و الگوریتم  مربوطه یک کردنشیال ساختیم
        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        //یک سکیوریتی توکن دیسکریپتور ساختیم
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claim), //کلایم را به موضوع زدیم
            Expires = DateTime.Now.AddMinutes(int.Parse(timeOuToken)),//تعداد روز های اعتبار توکن
            SigningCredentials = creds //کردنشیال بالا را در ساین این کردنشیال زدیم
        };
        var tokenHandler = new JwtSecurityTokenHandler();//یک توکن هندلر ساختیم
        var token = tokenHandler.CreateToken(tokenDescriptor);// توکن را می سازیم

        return tokenHandler.WriteToken(token);//با استفاده ار توکن هندلر توکن جدید را نوشته و برمیگردانیم

    }
}


