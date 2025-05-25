using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.NetworkInformation;
using BCLservice.DataStore;
using System.Data.SqlClient;
using System.Configuration;

namespace BCLservice.ServiceData
{
    public class dtAppVersions
    {
        private string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
        private SqlConnection _connection;

        public dtAppVersions() {

        }


        //public static DataTable returnDataTable()
        //{
        //    DataStore.AppVersions.AppVersion_SelectLatestDataTable atable = new DataStore.AppVersions.AppVersion_SelectLatestDataTable();
        //    DataStore.AppVersionsTableAdapters.AppVersion_SelectLatestTableAdapter atableadapter = new DataStore.AppVersionsTableAdapters.AppVersion_SelectLatestTableAdapter();
        //    atableadapter.Fill(atable);

        //    return atable;
        //}

        //public static DataRow returnAppVersionRow()
        //{
        //    DataStore.AppVersions.AppVersion_SelectLatestDataTable atable = new DataStore.AppVersions.AppVersion_SelectLatestDataTable();
        //    DataStore.AppVersionsTableAdapters.AppVersion_SelectLatestTableAdapter atableadapter = new DataStore.AppVersionsTableAdapters.AppVersion_SelectLatestTableAdapter();
        //    atableadapter.Fill(atable);

        //    return atable[0];
        //}

        //public static AppVersionObject returnAppVersionObject()
        //{
        //    BclDbConnection conn = new BclDbConnection();
        //    DataStore.AppVersions.AppVersion_SelectLatestDataTable atable = new DataStore.AppVersions.AppVersion_SelectLatestDataTable();
        //    DataStore.AppVersionsTableAdapters.AppVersion_SelectLatestTableAdapter atableadapter = new DataStore.AppVersionsTableAdapters.AppVersion_SelectLatestTableAdapter();
        //    atableadapter.Connection.ConnectionString = conn.ConnectionString;
        //    atableadapter.Fill(atable);
        //    DataRow drow = atable[0];
        //    AppVersionObject obj = new AppVersionObject();
        //    obj.SQLSVRversion = drow.Field<string>("SQLRversion");

        //    return obj;
        //}

        public static AppVersionObject returnAppVersionObject()
        {
            AppVersionObject obj = new AppVersionObject();
            string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(_connectionstring);
            BclDbConnection conn = new BclDbConnection();
            SqlCommand scmd = new SqlCommand("AppVersion_SelectLatest", _connection);
            DataTable dt = new DataTable();
            SqlDataAdapter td = new SqlDataAdapter(scmd);
            _connection.Open();
            td.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    obj.pk_id = dr.Field<int>("pk_id");
                    obj.created_date = dr.Field<DateTime>("created_date");
                    obj.effective_date = dr.Field<DateTime>("effective_date");
                    obj.DBName = dr.Field<string>("DBName");
                    obj.SQLServerName = dr.Field<string>("SQLServerName");
                    obj.SQLSVRversion = dr.Field<string>("SQLSVRversion");
                    obj.version_number = dr.Field<string>("versionstring");
                    obj.versionstring = dr.Field<string>("versionstring");
                    obj.version_id = dr.Field<int>("pk_id");
                }
            }

            return obj;
        }


    }
}
