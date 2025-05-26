using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.Configuration;
using global::BCLservice.DataStore;

namespace BCLservice.ServiceData
{
    public class dtCampus
    {
        private string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
        private SqlConnection _connection;

        public dtCampus()
        {

        }


        public static List<CampusObject> returnCampusObject()
        {
            CampusObject obj = new CampusObject();
            List<CampusObject> results = new List<CampusObject>();
            string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(_connectionstring);
            BclDbConnection conn = new BclDbConnection();
            SqlCommand scmd = new SqlCommand("LSC_Campus_Select", _connection);
            DataTable dt = new DataTable();
            SqlDataAdapter td = new SqlDataAdapter(scmd);
            _connection.Open();
            td.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new CampusObject();
                    obj.PK_Campus_Id = dr.Field<int>("PK_Campus_Id");
                    obj.Name_Short = dr.Field<string>("Name_Short");
                    obj.Name_Long = dr.Field<string>("Name_Long");
                    obj.Description = dr.Field<string>("Description");
                    obj.AddressStreet = dr.Field<string>("AddressStreet");
                    obj.AddressUnit = dr.Field<string>("AddressUnit");
                    obj.AddressCity = dr.Field<string>("AddressCity");
                    obj.AddressState = dr.Field<string>("AddressState");
                    obj.AddressZip = dr.Field<string>("AddressZip");
                    obj.IsActive = dr.Field<bool>("IsActive");
                    obj.IsDeleted = dr.Field<bool>("IsDeleted");
                    results.Add(obj);
                }
            }

            return results;
        }

        public static List<CampusObject> updateCampusObject(object request)
        {
            CampusObject obj = new CampusObject();
            List<CampusObject> results = new List<CampusObject>();
            string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(_connectionstring);
            BclDbConnection conn = new BclDbConnection();
            SqlCommand scmd = new SqlCommand("LSC_Campus_Update", _connection);
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandTimeout = 120;
            scmd.Parameters.Add(new SqlParameter("@Request", JsonConvert.SerializeObject(request)));
            DataTable dt = new DataTable();
            SqlDataAdapter td = new SqlDataAdapter(scmd);
            _connection.Open();
            td.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new CampusObject();
                    obj.PK_Campus_Id = dr.Field<int>("PK_Campus_Id");
                    obj.Name_Short = dr.Field<string>("Name_Short");
                    obj.Name_Long = dr.Field<string>("Name_Long");
                    obj.Description = dr.Field<string>("Description");
                    obj.AddressStreet = dr.Field<string>("AddressStreet");
                    obj.AddressUnit = dr.Field<string>("AddressUnit");
                    obj.AddressCity = dr.Field<string>("AddressCity");
                    obj.AddressState = dr.Field<string>("AddressState");
                    obj.AddressZip = dr.Field<string>("AddressZip");
                    obj.IsActive = dr.Field<bool>("IsActive");
                    obj.IsDeleted = dr.Field<bool>("IsDeleted");
                    results.Add(obj);
                }
            }

            return results;
        }

        public static CampusObjectRow createCampusObject(object request)
        {
            CampusObjectRow obj = new CampusObjectRow();
            string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(_connectionstring);
            BclDbConnection conn = new BclDbConnection();
            SqlCommand scmd = new SqlCommand("LSC_Campus_Create", _connection);
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandTimeout = 120;
            scmd.Parameters.Add(new SqlParameter("@Request", JsonConvert.SerializeObject(request)));
            DataTable dt = new DataTable();
            SqlDataAdapter td = new SqlDataAdapter(scmd);
            _connection.Open();
            td.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    obj.PK_Campus_Id = dr.Field<int>("PK_Campus_Id");
                    obj.Name_Short = dr.Field<string>("Name_Short");
                    obj.Name_Long = dr.Field<string>("Name_Long");
                    obj.Description = dr.Field<string>("Description");
                    obj.AddressStreet = dr.Field<string>("AddressStreet");
                    obj.AddressUnit = dr.Field<string>("AddressUnit");
                    obj.AddressCity = dr.Field<string>("AddressCity");
                    obj.AddressState = dr.Field<string>("AddressState");
                    obj.AddressZip = dr.Field<string>("AddressZip");
                    obj.IsActive = dr.Field<bool>("IsActive");
                    obj.IsDeleted = dr.Field<bool>("IsDeleted");
                }
            }

            return obj;
        }

        public static List<CampusObject> deleteCampusObject(object request)
        {
            CampusObject obj = new CampusObject();
            List<CampusObject> results = new List<CampusObject>();
            string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(_connectionstring);
            BclDbConnection conn = new BclDbConnection();
            SqlCommand scmd = new SqlCommand("LSC_Campus_Delete", _connection);
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandTimeout = 120;
            scmd.Parameters.Add(new SqlParameter("@Request", JsonConvert.SerializeObject(request)));
            _connection.Open();
            scmd.ExecuteNonQuery();
            return results;
        }


    }
}
