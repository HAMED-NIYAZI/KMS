using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Application.Dtos.HomePageSettingDto
{
    public class LoginHomePageSettingDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public Guid? OrganizationId { get; set; }
    }
}
