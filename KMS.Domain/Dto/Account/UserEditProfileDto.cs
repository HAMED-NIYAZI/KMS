using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Domain.Dto.Account
{
    public class UserEditProfileDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
         public required string Phone { get; set; }
         public required string Email { get; set; }
         public  string? Address { get; set; }
         public  string? About { get; set; }
     }
}
