using KMS.Data.Repositories.Account;
using KMS.Domain.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Application.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public UserLoginReturnDto? Login(UserLoginDto userLoginDto)
        {
            return accountRepository.Login(userLoginDto);
        }
    }
}
