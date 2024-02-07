using KMS.Domain.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Application.Services.AccountService
{
    public interface IAccountService
    {
        UserLoginReturnDto? Login(UserLoginDto userLoginDto);

    }
}
