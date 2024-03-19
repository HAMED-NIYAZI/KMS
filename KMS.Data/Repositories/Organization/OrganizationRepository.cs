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

                var script = @"INSERT INTO [dbo].Organizations
                              ([Id]
                             ,[SortingNumber]
                             ,[PersianTitle]
                             ,[EnglishTitle]
                             ,[Description]
                             ,[ParentId]
                             ,[CreateDate]
                             ,[LastUpdateDate]
                             ,[IsDeleted])
                             VALUES( 
                              @Id
                             ,@SortingNumber
                             ,@PersianTitle
                             ,@EnglishTitle
                             ,@Description
                             ,@ParentId
                             ,GETDATE()
                             ,GETDATE()
                             ,0)";

                await Task.Run(() => { ExecuteTsql(script, @params); });
                return 1;
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public async Task<int> Count()
        {
            try
            {
                var @params = new DynamicParameters();
                var script = @"SELECT COUNT(Id) FROM dbo.Organizations";
                var count = 0;
                await Task.Run(() => { count = ExecuteTsqlCount(script, @params); });
                return count;

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
                var script = "UPDATE [dbo].Organizations SET IsDeleted=1 WHERE Id=@Id";
                var @params = new DynamicParameters();
                @params.Add("Id", id, DbType.Guid);
                await Task.Run(() => { ExecuteTsql(script, @params); });
                return 1;
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public async Task<Domain.Organization?> Get(Guid id)
        {
            try
            {
                var script = "SELECT * From [dbo].Organizations WHERE Id=@Id";
                var @params = new DynamicParameters();
                @params.Add("Id", id, DbType.Guid);

                return await Task.FromResult(Get<Domain.Organization?>(script, @params, commandType: CommandType.Text));
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public async Task<Domain.Organization?> Get(string persianTitle)
        {
            try
            {
                var script = "SELECT * From [dbo].Organizations WHERE [PersianTitle]=@PersianTitle";
                var @params = new DynamicParameters();
                @params.Add("@PersianTitle", persianTitle, DbType.String);

                return await Task.FromResult(Get<Domain.Organization?>(script, @params, commandType: CommandType.Text));
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public async Task<List<Domain.Organization>?> GetAll()
        {
            try
            {
                var script = " SELECT * FROM   [dbo].Organizations  WHERE IsDeleted=0";
                var @params = new DynamicParameters();
                List<Domain.Organization> list = await Task.FromResult(GetAll<Domain.Organization>(script, @params, commandType: CommandType.Text));
                return list;
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public async Task<List<Domain.Organization>?> GetPage(int pageNumber = 1, int rowsOfPage = 10, string sortingCol = "Id", string sortType = "ASC")
        {
            try
            {
                var script = @"SELECT * FROM [dbo].Organizations
                            ORDER BY 
                            CASE WHEN @SortingCol = 'Id' AND @SortType ='ASC' THEN Id END ,
                            CASE WHEN @SortingCol = 'Id' AND @SortType ='DESC' THEN ID END DESC,
                            CASE WHEN @SortingCol = 'PersianTitle' AND @SortType ='ASC' THEN PersianTitle END ,
                            CASE WHEN @SortingCol = 'PersianTitle' AND @SortType ='DESC' THEN PersianTitle END DESC
                            OFFSET (@PageNumber-1)*@RowsOfPage ROWS
                            FETCH NEXT @RowsOfPage ROWS ONLY";

                var @params = new DynamicParameters();
                @params.Add("PageNumber", pageNumber, DbType.Int32);
                @params.Add("RowsOfPage", rowsOfPage, DbType.Int32);
                @params.Add("SortingCol", sortingCol, DbType.String);
                @params.Add("SortType", sortType, DbType.String);

                List<Domain.Organization> list = await Task.FromResult(GetAll<Domain.Organization>(script, @params, commandType: CommandType.Text));
                return list;
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public async Task<int> Update(Domain.Organization organization)
        {
            try
            {
                var script = @"UPDATE [dbo].[Organizations] 
                            SET SortingNumber=@SortingNumber, PersianTitle=@PersianTitle,ParentId=@ParentId,LastUpdateDate=GETDATE()
                            WHERE Id=@Id
                            SELECT @@rowcount";

                var @params = new DynamicParameters();
                @params.Add("Id", organization.Id, DbType.Guid);
                @params.Add("SortingNumber", organization.SortingNumber, DbType.Int32);
                @params.Add("PersianTitle", organization.PersianTitle, DbType.String);
                @params.Add("ParentId", organization.ParentId, DbType.Guid);

                var list = await Task.FromResult(Update<int>(script, @params, commandType: CommandType.Text));
                return list;
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
