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
        List<Domain.Organization> GetAll();
        List<Domain.Organization> GetAll(int page , int pageCount);
        Domain.Organization? Get(Guid id);
        Domain.Organization? Get(string name);
        int Delete(Guid id);
        int Delete(string name);
        int Update(Domain.Organization organization);
        int Add(Domain.Organization organization);
    }
}
