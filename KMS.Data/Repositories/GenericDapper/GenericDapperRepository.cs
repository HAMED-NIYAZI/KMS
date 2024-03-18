using Dapper;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        //Just Run a TSQL
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

        //Just Run a TSQL and return an int
        public int ExecuteTsqlCount(string script, DynamicParameters @params)
        {


            using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    // Correctly pass the transaction object to the SqlCommand
                    using (var command = new SqlCommand(script, (SqlConnection)db, (SqlTransaction)tran))
                    {
                        // Execute the command within the transaction
                        var count= (int)command.ExecuteScalar();
                        tran.Commit();
                        return count;

                    }
                 }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of any error
                    tran.Rollback();
                    throw; // Rethrow the exception without wrapping it
                }
            }
            catch (Exception ex)
            {
                throw; // Rethrow the exception without wrapping it
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
