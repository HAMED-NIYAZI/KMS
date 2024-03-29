﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Domain.Dto.Account
{
    public class UserProfileDto
    {
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Phone { get; set; }
        public bool? ConfirmedPhone { get; set; }
        public string? Email { get; set; }
        public bool? ConfirmedEmail { get; set; }
        public string? Address { get; set; }
        public string? CodeMeli { get; set; }
        public string? PersonnelNumber { get; set; }
        public string? About { get; set; }
        public string? PositionName { get; set; }
        public string? PositionId { get; set; }
        public string? ImagePath { get; set; }
        public Guid? GradeId { get; set; }
        public string? GradeName { get; set; }
        public Guid? ChartId { get; set; }
        public string? ChartPersianTitleName { get; set; }
        public Guid? OrganizationId { get; set; }
        public string? OrganizationPersianTitleName { get; set; }

     }
}

