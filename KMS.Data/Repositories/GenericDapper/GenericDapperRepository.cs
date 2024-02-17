using Dapper;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace KMS.Data.Repositories.GenericDapper
{
#nullable enable

    public class GenericDapperRepository : IGenericDapperRepository
    {
        private readonly IConfiguration config;
        private readonly string connectionstring = "KMSConnectionString";

        public GenericDapperRepository(IConfiguration config)
        {
            this.config = config;
        }

        public int Count(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(config.GetConnectionString(connectionstring));
            return db.Query<int>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public static void Dispose()
        {

        }

        public void ExecuteTsql(string script, DynamicParameters parms)
        {
              using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    // Pass the transaction object as a parameter to the Query method
                    db.Query(script, parms, commandType: CommandType.Text, transaction: tran);
                    tran.Commit();
                 }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw; // Do not wrap the exception again, just rethrow it
                }
            }
            catch (Exception ex)
            {
                throw; // Do not wrap the exception again, just rethrow it
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }

        public T? Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = new SqlConnection(config.GetConnectionString(connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(config.GetConnectionString(connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(config.GetConnectionString(connectionstring));
        }

        public T? Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T? result;
            using IDbConnection db = new SqlConnection(config.GetConnectionString(connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public T? Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T? result;
            using IDbConnection db = new SqlConnection(config.GetConnectionString(connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        //public T? ExecuteStoredProcedureGetOne<T>(string sp, DynamicParameters parms )
        //{
        //    //using (var connection = new SqlConnection(config.GetConnectionString(connectionstring)))
        //    //{
        //    //    connection.Open();
        //    //    var s= connection.Query<T>(sp, parms, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //    //}

        //    T? result;
        //    using IDbConnection db = GetDbconnection();
        //    try
        //    {
        //        if (db.State == ConnectionState.Closed)
        //            db.Open();

        //        using var tran = db.BeginTransaction();
        //        try
        //        {
        //            result = db.Query<T>(sp, parms, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //            tran.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            tran.Rollback();
        //            throw ex;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (db.State == ConnectionState.Open)
        //            db.Close();
        //    }

        //    return result;

        //    //T? result;
        //    //using IDbConnection db = GetDbconnection();
        //    //try
        //    //{
        //    //    if (db.State == ConnectionState.Closed)
        //    //        db.Open();

        //    //    using var tran = db.BeginTransaction();
        //    //    try
        //    //    {
        //    //        result = db.Query<T>(sp, parms, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //    //        tran.Commit();
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        tran.Rollback();
        //    //        throw ex;
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //    //finally
        //    //{
        //    //    if (db.State == ConnectionState.Open)
        //    //        db.Close();
        //    //}

        //    //return result;



        //}

        public T? ExecuteStoredProcedureGetOne<T>(string sp, DynamicParameters parms)
        {
            T? result;
            using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    // Pass the transaction object as a parameter to the Query method
                    result = db.Query<T>(sp, parms, commandType: CommandType.StoredProcedure, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw; // Do not wrap the exception again, just rethrow it
                }
            }
            catch (Exception ex)
            {
                throw; // Do not wrap the exception again, just rethrow it
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }
       
        public List<T>? ExecuteStoredProcedureGetList<T>(string sp, DynamicParameters parms)
        {
            using (var connection = new SqlConnection(config.GetConnectionString(connectionstring)))
            {
                connection.Open();
                return (List<T>)connection.Query<List<T>>(sp, parms, commandType: CommandType.StoredProcedure);
            }
        }

        public T? ExecuteTsql<T>(string script, DynamicParameters parms)
        {
            T? result;
            using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    // Pass the transaction object as a parameter to the Query method
                    result = db.Query<T>(script, parms, commandType: CommandType.Text, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw; // Do not wrap the exception again, just rethrow it
                }
            }
            catch (Exception ex)
            {
                throw; // Do not wrap the exception again, just rethrow it
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }


    }
}
