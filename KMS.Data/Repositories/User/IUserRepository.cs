﻿using KMS.Domain.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Data.Repositories.User
{
    public interface IUserRepository
    {
        UserProfileDto? GetById(Guid id);
        bool ChangePasswordByUser(UserChangePasswordDto model);
        string GetPassword(Guid Id);
        void EditUserProfile(UserEditProfileDto model);
        void EditUserProfileImage(Guid Id,string imagePath);
        void RequestRegister(RequestRegisterDto model);

    }
}
