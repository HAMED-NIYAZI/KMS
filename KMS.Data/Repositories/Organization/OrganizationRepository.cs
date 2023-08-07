using Data.Context;
using KMS.Data.Repositories.GenericDapper;
using KMS.Data.Repositories.GenericEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace KMS.Data.Repositories.Organization
{
    public class OrganizationRepository : GenericDapperRepository, IOrganizationRepository
    {
        public OrganizationRepository(IConfiguration config) : base(config)
        {
        }

        public int Add(Domain.Organization organization)
        {
            //  string sp = "[dbo].[Organization.Insert]";
            //   Insert<Domain.Organization>(sp,);
            return 0;
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Delete(string name)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Organization> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Domain.Organization> GetAll(int page, int pageCount)
        {
            throw new NotImplementedException();
        }

        public Domain.Organization? Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Domain.Organization? Get(string name)
        {
            throw new NotImplementedException();
        }

        public int Update(Domain.Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
