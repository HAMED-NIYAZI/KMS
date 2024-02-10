using Dapper;
using KMS.Data.Repositories.GenericDapper;
using KMS.Domain.Dto.Account;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Data.Repositories.User
{
    public class UserRepository : GenericDapperRepository, IUserRepository
    {
        public UserRepository(IConfiguration config) : base(config)
        {
        }
        public UserProfileDto? GetById(Guid id)
        {
            var sp = "[dbo].[UserProfile]";

 
            var param = new DynamicParameters();
            param.Add("@UserId",id);

            var res = ExecuteStoredProcedureGetOne<UserProfileDto>(sp, param);

            return res;
        }
    }
}
