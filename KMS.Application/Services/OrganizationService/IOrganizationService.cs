using KMS.Application.Dtos.OrganizationDto;
using KMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Application.Services.OrganizationService
{
    public interface IOrganizationService
    {
        List<OrganizationDto> GetAll();
        OrganizationDto? Get(Guid id);
        OrganizationDto? Get(string name);
        bool Delete(Guid id);
        bool Delete(string name);
        bool Update(OrganizationDto organizationDto);
        bool Add(OrganizationDto organizationDto);
    }
}
