using Dapper;
using Data.Context;
using KMS.Data.Repositories.GenericDapper;
using KMS.Data.Repositories.GenericEF;
using KMS.Domain;
using KMS.Domain.Dto.Account;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Data.Repositories.Account
{
    public class AccountRepository : GenericDapperRepository, IAccountRepository
    {

        public AccountRepository(IConfiguration config) : base(config)
        {
        }

        public UserLoginReturnDto? Login(UserLoginDto userLoginDto)
        {
            var sp = "[dbo].[Login]";

            var param= new DynamicParameters();
            param.Add("@UserName", userLoginDto.UserName);
            param.Add("@Password", userLoginDto.Password);

            var res = ExecuteStoredProcedureGetOne<UserLoginReturnDto>(sp, param);
 
            return  res;
        }
    }
}
