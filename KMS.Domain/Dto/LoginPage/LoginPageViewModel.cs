﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Domain.Dto.LoginPage
{
    public class LoginPageViewModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public Guid? OrganizationId { get; set; }

    }
}