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


            var res = ExecuteTsql<string>(sp, param);

            return res;
        }

        public UserProfileDto? GetById(Guid id)
        {
            var sp = "[dbo].[UserProfile]";


            var param = new DynamicParameters();
            param.Add("@UserId", id);

            var res = ExecuteStoredProcedureGetOne<UserProfileDto>(sp, param);

            return res;
        }

        public void EditUserProfile(UserEditProfileDto model)
        {
            var sp = @"UPDATE  [dbo].[Users]
                       SET FirstName=@FirstName,LastName=@LastName,Phone=@Phone,Email=@Email,[Address]=@Address,About=@About,LastUpdateDate=getdate()
                       WHERE Id=@Id
                       ";


            var param = new DynamicParameters();
            param.Add("@Id", model.Id);
            param.Add("@FirstName", model.FirstName);
            param.Add("@LastName", model.LastName);
            param.Add("@Phone", model.Phone);
            param.Add("@Email", model.Email);
            param.Add("@Address", model.Address);
            param.Add("@About", model.About);

            ExecuteTsql(sp, param);

        }

        public void EditUserProfileImage(Guid Id, string imagePath)
        {
            var script = @"UPDATE  [dbo].[Users]
                       SET ImagePath=@ImagePath
                       WHERE Id=@Id
                       ";

            var param = new DynamicParameters();
            param.Add("@Id", Id);
            param.Add("@ImagePath", imagePath);

            ExecuteTsql(script, param);

        }

        public void RequestRegister(RequestRegisterDto model)
        {
            var script = "SELECT UserName FROM [dbo].[Users] WHERE UserName=@UserName";


            var param = new DynamicParameters();
            param.Add("@UserName", model.CodeMeli);

            var res = ExecuteStoredProcedureGetOne<string>(script, param);

            if (res == model.CodeMeli) throw new Exception("کاربری با این کد ملی در سیستم وجود دارد.");


           var  scriptInsert = @"INSERT INTO [dbo].[Users](FirstName,LastName,Password,Phone,Email,CodeMeli,PersonnelNumber,ChartId,Status)
                       VALUES(@FirstName,@LastName,@Password,@Phone,@Email,@CodeMeli,@PersonnelNumber,@ChartId,0)";

            var Insert = new DynamicParameters();
            param.Add("@FirstName", model.FirstName);
            param.Add("@LastName", model.LastName);
            param.Add("@Password", model.Password);
            param.Add("@Phone", model.Phone);
            param.Add("@Email", model.Email);
            param.Add("@CodeMeli", model.CodeMeli);
            param.Add("@PersonnelNumber", model.PersonnelNumber);
            param.Add("@ChartId", model.ChartId);


           ExecuteTsql(scriptInsert, Insert);
        }
    }
}
