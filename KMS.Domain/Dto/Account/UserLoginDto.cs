﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Domain.Dto.Account
{
    public class UserLoginDto
    {
        public required  string UserName { get; set; }
        public required string Password { get; set; }
    }
}
