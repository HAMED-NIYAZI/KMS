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

        public bool ChangePasswordByUser(UserChangePasswordDto model)
        {
            var sp = @"update [dbo].[Users]
                       set Password=@Password
                       where Id=@Id";


            var param = new DynamicParameters();
            param.Add("@Id", model.Id);
            param.Add("@Password", model.NewPassword);

             ExecuteTsql(sp, param);
            return true;
        }

        public string GetPassword(Guid Id)
        {
            var sp = @"SELECT Password FROM [dbo].[Users]
                       Where Id=@Id";


            var param = new DynamicParameters();
            param.Add("@Id", Id);


            var res = ExecuteTsqlGetOne<string>(sp, param);

            return res;
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
