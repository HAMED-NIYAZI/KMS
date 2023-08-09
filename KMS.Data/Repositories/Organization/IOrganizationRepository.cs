using KMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KMS.Domain.Enums;

namespace KMS.Data.Repositories.Organization
{
    public interface IOrganizationRepository
    {
        Task<List<Domain.Organization>> GetAll();
        Task<List<Domain.Organization>> GetPage(int PageNumber = 1, int RowsOfPage = 10,string SortingCol = "Id" ,string SortType= "ASC");
        Task<Domain.Organization?> Get(Guid id);
        Task<Domain.Organization?> Get(string name);
        Task<int> Delete(Guid id);
        Task<int> Delete(string name);
        Task<int> Update(Domain.Organization organization);
        Task<int> Add(Domain.Organization organization);
        Task<int> Count();
    }
}
