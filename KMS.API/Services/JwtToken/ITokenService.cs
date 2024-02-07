using KMS.Domain.Dto.Account;

namespace KMS.API.Services.JwtToken;

public interface ITokenService
{
    string CreateToken(UserLoginReturnDto user);
    string CreateToken(int userId);
}
