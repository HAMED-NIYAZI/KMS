using KMS.Domain.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Data.Repositories.Account
{
    public interface IAccountRepository
    {

        UserLoginReturnDto? Login(UserLoginDto userLoginDto);
    }
}
