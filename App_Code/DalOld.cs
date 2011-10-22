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

}