using KMS.Domain;
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Data.Repositories.Organization
{
    public interface IOrganizationRepository
    {
        Task<List<Domain.Organization>> GetAll();
        Task<List<Domain.Organization>> GetAll(int page , int pageCount);
        Task<Domain.Organization?> Get(Guid id);
        Task<Domain.Organization?> Get(string name);
        Task<int> Delete(Guid id);
        Task<int> Delete(string name);
        Task<int> Update(Domain.Organization organization);
        Task<int> Add(Domain.Organization organization);
    }
}
