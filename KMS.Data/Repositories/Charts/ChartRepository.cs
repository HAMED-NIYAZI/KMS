using Dapper;
using KMS.Data.Repositories.GenericDapper;
using KMS.Domain;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace KMS.Data.Repositories.Charts
{
    public class ChartRepository : GenericDapperRepository, IChartRepository
    {
        public ChartRepository(IConfiguration config) : base(config)
        {
        }
        public async Task<int> Add(Chart chart)
        {
            try
            {
                var @params = new DynamicParameters();
                @params.Add("Id", chart.Id, DbType.Guid);
                @params.Add("SortingNumber", chart.SortingNumber, DbType.Int32);
                @params.Add("PersianTitle", chart.PersianTitle, DbType.String);
                @params.Add("EnglishTitle", chart.EnglishTitle, DbType.String);
                @params.Add("Description", chart.Description, DbType.String);
                @params.Add("ParentId", chart.ParentId, DbType.Guid);
                @params.Add("OrganizationId", chart.OrganizationId, DbType.Guid);

                return await Task.FromResult(Insert<int>("[dbo].[Chart.Insert]", @params, commandType: CommandType.StoredProcedure));
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
                return await Task.FromResult(Count("[dbo].[Chart.Count]", @params, commandType: CommandType.StoredProcedure));
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
                return await Task.FromResult(Update<int>("[dbo].[Chart.DeleteById]", @params, commandType: CommandType.StoredProcedure));
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
                return await Task.FromResult(Update<int>("[dbo].[Chart.DeleteByName]", @params, commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                //Log
                return 0;
            }
        }

        public async Task<Chart?> Get(Guid id)
        {
            try
            {
                var @params = new DynamicParameters();
                @params.Add("Id", id, DbType.Guid);
                return await Task.FromResult(Get<Chart?>("[dbo].[Chart.GetById]", @params, commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                //Log
                return null;
            }
        }

        public async Task<Chart?> Get(string name)
        {
            try
            {
                var @params = new DynamicParameters();
                @params.Add("Id", name, DbType.String);
                return await Task.FromResult(Get<Chart>("[dbo].[Chart.GetByName]", @params, commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                //Log
                return null;
            }
        }

        public async Task<List<Chart>?> GetAll()
        {
            try
            {
                var @params = new DynamicParameters();
                List<Chart> list = await Task.FromResult(GetAll<Chart>("[dbo].[Organization.GetAll]", @params, commandType: CommandType.StoredProcedure));
                return list;
            }
            catch (Exception)
            {
                //Log
                return null;
            }
        }


        public async Task<List<Chart>?> GetPage(int PageNumber = 1, int RowsOfPage = 10, string SortingCol = "Id", string SortType = "ASC")
        {
            try
            {
                var @params = new DynamicParameters();
                @params.Add("PageNumber", PageNumber, DbType.Int32);
                @params.Add("RowsOfPage", RowsOfPage, DbType.Int32);
                @params.Add("SortingCol", SortingCol, DbType.String);
                @params.Add("SortType", SortType, DbType.String);

                List<Chart> list = await Task.FromResult(GetAll<Chart>("[dbo].[Chart.GetPage]", @params, commandType: CommandType.StoredProcedure));
                return list;
            }
            catch (Exception)
            {
                //Log
                return null;
            }
        }

        public async Task<int> Update(Chart chart)
        {
            try
            {
                var @params = new DynamicParameters();
                @params.Add("Id", chart.Id, DbType.Guid);
                @params.Add("SortingNumber", chart.SortingNumber, DbType.Int32);
                @params.Add("PersianTitle", chart.PersianTitle, DbType.String);
                @params.Add("ParentId", chart.ParentId, DbType.Guid);
                @params.Add("OrganizationId", chart.OrganizationId, DbType.Guid);

                var list = await Task.FromResult(Update<int>("[dbo].[Chart.Update]", @params, commandType: CommandType.StoredProcedure));
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
