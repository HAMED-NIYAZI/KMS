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
        Task<List<OrganizationDto>> GetAll();
        Task<List<OrganizationDto>> GetPage(int PageNumber = 1, int RowsOfPage = 10, string SortingCol = "Id", string SortType = "ASC");
        Task<OrganizationDto?> Get(Guid id);
        Task<OrganizationDto?> Get(string name);
        Task<int> Delete(Guid id);
        Task<int> Delete(string name);
        Task<int> Update(OrganizationDto organization);
        Task<int> Add(OrganizationDto organization);
    }
}
