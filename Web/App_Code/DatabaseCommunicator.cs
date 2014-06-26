using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

public static class DatabaseCommunicator
{
    private static DatabaseConnector dbConnector = new DatabaseConnector("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~") + "database.accdb");

    #region general commands
    private static DataTable ExecSQLDataTable(OleDbCommand command)
    {
        DataSet ds = ExecSQLDataSet(command);
        return ds.Tables[0];
    }

    private static DataSet ExecSQLDataSet(OleDbCommand command)
    {
        OleDbDataAdapter adapter = ExecSQLDataAdapter(command);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        return ds;
    }

    private static OleDbDataAdapter ExecSQLDataAdapter(OleDbCommand command)
    {
        string dbConnId = command.CommandText + command.GetHashCode();
        command.Connection = dbConnector.AssignNewConnectionToDbConn(dbConnId);

        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
        DataSet ds = new DataSet();

        dbConnector.RejectConnectionFromDbConn(dbConnId);

        return adapter;
    }

    private static int ExecSQLNonQuery(OleDbCommand command)
    {
        string dbConnId = command.CommandText + command.GetHashCode();
        command.Connection = dbConnector.AssignNewConnectionToDbConn(dbConnId);
        command.Connection.Open();

        int affectingRows = command.ExecuteNonQuery();

        command.Connection.Close();
        dbConnector.RejectConnectionFromDbConn(dbConnId);

        return affectingRows;
    }

    private static object ExecSQLScalar(OleDbCommand command)
    {
        object result = ExecSQLDataTable(command).Rows[0][0];

        return result;
    }

    public static DataTable SelectFromTable(OleDbCommand command)
    {
        return ExecSQLDataTable(command);
    }

    public static DataSet SelectFromTableReturnDataSet(OleDbCommand command)
    {
        return ExecSQLDataSet(command);
    }

    public static OleDbDataAdapter SelectFromTableReturnDataAdapter(OleDbCommand command)
    {
        return ExecSQLDataAdapter(command);
    }

    public static object SelectSingleFromTable(OleDbCommand command)
    {
        return ExecSQLScalar(command);
    }

    public static int InsertIntoTable(OleDbCommand command)
    {
        return ExecSQLNonQuery(command);
    }

    public static int UpdateFromTable(OleDbCommand command)
    {
        return ExecSQLNonQuery(command);
    }

    public static int DeleteFromTable(OleDbCommand command)
    {
        return ExecSQLNonQuery(command);
    }
    #endregion

    #region Database Connector
    private sealed class DatabaseConnector
    {
        private OleDbConnection dbConn;
        private const int Capacity = 15;
        private List<object> pool = new List<object>(Capacity);

        public DatabaseConnector(string connectionString)
        {
            dbConn = new OleDbConnection(connectionString);
        }

        public OleDbConnection AssignNewConnectionToDbConn(string identifier)
        {
            if (pool.Count < Capacity)
            {
                pool.Add(identifier);
            }
            else
            {
                throw new MaxConnectionExceedException();
            }

            return this.dbConn;
        }

        public string RejectConnectionFromDbConn(string identifier)
        {
            bool success = pool.Remove(identifier);
            if (pool.Count == 0) dbConn.Close();
            return success ? identifier : null;
        }

        public sealed class MaxConnectionExceedException : Exception
        {
            public MaxConnectionExceedException()
                : base("The maximum connection with the database connection has exceed. "
                       + "You should also better to handle this exception on your code.")
            {
            }
        }
    }
    #endregion
}