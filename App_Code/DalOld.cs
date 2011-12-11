using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for TeacherDAL
/// </summary>
public class DalOld
{
    ConnectionStringSettings _configSettings = ConfigurationManager.ConnectionStrings["CocaChildConnectionString"];

    public DataView SchoolListView()
    {
        DataTable dt = new DataTable();        

        DbProviderFactory _dbProvider = DbProviderFactories.GetFactory(_configSettings.ProviderName);

        //Create a connection to connect as per provided provider name 
        using (DbConnection _dbConn = _dbProvider.CreateConnection())
        {
            _dbConn.ConnectionString = _configSettings.ConnectionString;
            _dbConn.Open();
            //Create a command to execute 
            DbCommand _dbCommand;
            _dbCommand = _dbProvider.CreateCommand();
            _dbCommand.Connection = _dbConn;
            //_dbCommand.CommandText = "Select * from Schools";
            _dbCommand.CommandText = "Select SchoolID, SchoolName, City, StateName, Zip FROM [CocaChild].[dbo].[Schools] sch, [CocaChild].[dbo].[States] st Where sch.stateid = st.stateid";
            _dbCommand.CommandType = CommandType.Text;
            
            DbDataAdapter _dbDataAdaptor = _dbProvider.CreateDataAdapter();
            _dbDataAdaptor.SelectCommand = _dbCommand;

            _dbDataAdaptor.Fill(dt);
            _dbCommand.Connection.Close();
            DataView dv = new DataView(dt);
            var x = dv.Count;
            return dv;
        }
    }


    public DataView SurveyListView(int aprID)
    {
        DataTable dt = new DataTable();
        //ConnectionStringSettings _configSettings = ConfigurationManager.ConnectionStrings["sql2008r2_847344_surveysConnectionString"];
        ConnectionStringSettings _configSettings = ConfigurationManager.ConnectionStrings["LocalSqlServer"];
        DbProviderFactory _dbProvider = DbProviderFactories.GetFactory(_configSettings.ProviderName);
        //Create a connection to connect as per provided provider name 
        using (DbConnection _dbConn = _dbProvider.CreateConnection())
        {
            _dbConn.ConnectionString = _configSettings.ConnectionString;
            _dbConn.Open();
            //Create a command to execute 
            DbCommand _dbCommand;
            _dbCommand = _dbProvider.CreateCommand();
            _dbCommand.Connection = _dbConn;
            _dbCommand.CommandText = "Students_ByAprID_sps";
            _dbCommand.CommandType = CommandType.StoredProcedure;

            DbParameter parameter1 = _dbProvider.CreateParameter();
            parameter1.ParameterName = "@AprID";
            parameter1.DbType = DbType.Int32;
            parameter1.Value = aprID;
            _dbCommand.Parameters.Add(parameter1);      
         
            DbDataAdapter _dbDataAdaptor = _dbProvider.CreateDataAdapter();
            _dbDataAdaptor.SelectCommand = _dbCommand;
            _dbDataAdaptor.Fill(dt);
            _dbCommand.Connection.Close();

            DataView dv = new DataView(dt);
            return dv; 

        }
 
    }

}