using Dapper;
using System.Data.Common;
using System.Data;

namespace KMS.Data.Repositories.GenericDapper
{
    public interface IGenericDapperRepository
    {
        DbConnection GetDbconnection();
        T? Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        void ExecuteTsql(string script, DynamicParameters parms);
        T? Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T? Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        int Count(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T? ExecuteStoredProcedureGetOne<T>(string sp, DynamicParameters parms);
        List<T>? ExecuteStoredProcedureGetList<T>(string sp, DynamicParameters parms);
        T? ExecuteTsql<T>(string script, DynamicParameters parms);


    }
}
