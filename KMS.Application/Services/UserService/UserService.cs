using KMS.Common.Tools.Security;
using KMS.Data.Repositories.User;
using KMS.Domain.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Application.Services.UserService
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool ChangePasswordByUser(UserChangePasswordDto model)
        {
            if (model == null) throw new Exception("Model is null");
            if (model.ConfirmPassword != model.NewPassword) throw new Exception("NewPassword and ConfirmNewPassword does not match");
            if ( model.NewPassword.Length==0) throw new Exception("NewPassword is null");

            if (HashPassword.MD5Hash(model.OldPassword)!=userRepository.GetPassword(model.Id)) throw new Exception("OldPassword is not correct");

            model.NewPassword = HashPassword.MD5Hash(model.NewPassword);
            return userRepository.ChangePasswordByUser(model);
        }

        public UserProfileDto GetById(Guid id)
        {
            return userRepository.GetById(id);
        }
    }
}
