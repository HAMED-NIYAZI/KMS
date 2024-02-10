using KMS.Domain.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Application.Services.UserService
{
    public interface IUserService
    {
        UserProfileDto? GetById(Guid id);
    }
}
