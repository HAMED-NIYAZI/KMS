using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Application.Dtos.OrganizationDto
{
    public class OrganizationDeleteDto
    {
        public Guid Id { get; set; }
        public bool isDeleted { get; set; }
    }
}
