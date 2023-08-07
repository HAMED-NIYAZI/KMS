using Dapper;
using Data.Context;
using KMS.Data.Repositories.GenericDapper;
using KMS.Data.Repositories.GenericEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KMS.Data.Repositories.Organization
{
    public class OrganizationRepository : GenericDapperRepository, IOrganizationRepository
    {
        public OrganizationRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<int> Add(Domain.Organization organization)
        {
            try
            {
                string sp = "[dbo].[Organization.Insert]";
                var @params = new DynamicParameters();
                @params.Add("Id", organization.Id, DbType.Guid);
                @params.Add("SortingNumber", organization.SortingNumber, DbType.Int32);
                @params.Add("PersianTitle", organization.PersianTitle, DbType.String);
                @params.Add("EnglishTitle", organization.EnglishTitle, DbType.String);
                @params.Add("Description", organization.Description, DbType.String);
                @params.Add("ParentId", organization.ParentId, DbType.Guid);
                var result = await Task.FromResult(Insert<Domain.Organization>(sp, @params, commandType: CommandType.StoredProcedure));
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Organization?> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Organization?> Get(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Organization>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Organization>> GetAll(int page, int pageCount)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Domain.Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
