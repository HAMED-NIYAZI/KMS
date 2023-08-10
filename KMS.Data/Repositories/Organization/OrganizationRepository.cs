using Dapper;
using Data.Context;
using KMS.Data.Repositories.GenericDapper;
using KMS.Data.Repositories.GenericEF;
using KMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using static KMS.Domain.Enums;
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
                var @params = new DynamicParameters();
                @params.Add("Id", organization.Id, DbType.Guid);
                @params.Add("SortingNumber", organization.SortingNumber, DbType.Int32);
                @params.Add("PersianTitle", organization.PersianTitle, DbType.String);
                @params.Add("EnglishTitle", organization.EnglishTitle, DbType.String);
                @params.Add("Description", organization.Description, DbType.String);
                @params.Add("ParentId", organization.ParentId, DbType.Guid);

                return await Task.FromResult(Insert<int>("[dbo].[Organization.Insert]", @params, commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                //Log
                return 0;
            }
        }

        public async Task<int> Count()
        {
            try
            {
                var @params = new DynamicParameters();
                return await Task.FromResult(Count("[dbo].[Organization.Count]", @params, commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                //Log
                return 0;
            }
        }

        public async Task<int> Delete(Guid id)
        {
            try
            {
                var @params = new DynamicParameters();
                @params.Add("Id", id, DbType.Guid);
                return await Task.FromResult(Update<int>("[dbo].[Organization.DeleteById]", @params, commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                //Log
                return 0;
            }
        }

        public async Task<int> Delete(string name)
        {
            try
            {
                var @params = new DynamicParameters();
                @params.Add("PersianTitle", name, DbType.String);
                return await Task.FromResult(Update<int>("[dbo].[Organization.DeleteByName]", @params, commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                //Log
                return 0;
            }
        }

        public async Task<Domain.Organization?> Get(Guid id)
        {
            try
            {
                var @params = new DynamicParameters();
                @params.Add("Id", id, DbType.Guid);
                return await Task.FromResult(Get<Domain.Organization?>("[dbo].[Organization.GetById]", @params, commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                //Log
                return null;
            }
        }

        public async Task<Domain.Organization?> Get(string name)
        {
            try
            {
                var @params = new DynamicParameters();
                @params.Add("Id", name, DbType.String);
                return await Task.FromResult(Get<Domain.Organization>("[dbo].[Organization.GetByName]", @params, commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                //Log
                return null;
            }
        }

        public async Task<List<Domain.Organization>?> GetAll()
        {
            try
            {
                var @params = new DynamicParameters();
                List<Domain.Organization> list = await Task.FromResult(GetAll<Domain.Organization>("[dbo].[Organization.GetAll]", @params, commandType: CommandType.StoredProcedure));
                return list;
            }
            catch (Exception)
            {
                //Log
                return null;
            }
        }


        public async Task<List<Domain.Organization>?> GetPage(int PageNumber = 1, int RowsOfPage = 10, string SortingCol = "Id", string SortType = "ASC")
        {
            try
            {
                var @params = new DynamicParameters();
                @params.Add("PageNumber", PageNumber, DbType.Int32);
                @params.Add("RowsOfPage", RowsOfPage, DbType.Int32);
                @params.Add("SortingCol", SortingCol, DbType.String);
                @params.Add("SortType", SortType, DbType.String);

                List<Domain.Organization> list = await Task.FromResult(GetAll<Domain.Organization>("[dbo].[Organization.GetPage]", @params, commandType: CommandType.StoredProcedure));
                return list;
            }
            catch (Exception)
            {
                //Log
                return null;
            }
        }

        public async Task<int> Update(Domain.Organization organization)
        {
            try
            {
                var @params = new DynamicParameters();
                @params.Add("Id", organization.Id, DbType.Guid);
                @params.Add("SortingNumber", organization.SortingNumber, DbType.Int32);
                @params.Add("PersianTitle", organization.PersianTitle, DbType.String);
                @params.Add("ParentId", organization.ParentId, DbType.Guid);
 
               var list = await Task.FromResult(Update<int>("[dbo].[Organization.Update]", @params, commandType: CommandType.StoredProcedure));
                return list;
            }
            catch (Exception)
            {
                //Log
                return 0;
            }
        }
    }
}
