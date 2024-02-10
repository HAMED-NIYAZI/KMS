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
        public UserProfileDto GetById(Guid id)
        {
           return userRepository.GetById(id);
        }
    }
}
