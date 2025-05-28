using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LSCservice.ServiceData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Net.NetworkInformation;
    using System.Data.SqlClient;
    using System.Configuration;
    using global::LSCservice.DataStore;

    namespace BCLservice.ServiceData
    {
        public class dtSource
        {
            private string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            private SqlConnection _connection;

            public dtSource()
            {

            }


            public static List<SourceObject> returnSourceObject()
            {
                SourceObject obj = new SourceObject();
                List<SourceObject> results = new List<SourceObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Source_Select", _connection);
                DataTable dt = new DataTable();
                SqlDataAdapter td = new SqlDataAdapter(scmd);
                _connection.Open();
                td.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj = new SourceObject();
                        obj.PK_Source_Id = dr.Field<int>("PK_Source_Id");
                        obj.Source_Name = dr.Field<string>("Source_Name");
                        obj.SourceDescription = dr.Field<string>("SourceDescription");
                        obj.AddressStreet = dr.Field<string>("AddressStreet");
                        obj.AddressUnit = dr.Field<string>("AddressUnit");
                        obj.AddressCity = dr.Field<string>("AddressCity");
                        obj.AddressState = dr.Field<string>("AddressState");
                        obj.AddressZip = dr.Field<string>("AddressZip");
                        obj.IsActive = dr.Field<bool>("IsActive");
                        obj.IsDeleted = dr.Field<bool>("IsDeleted");
                        obj.OfficePhoneNumber = dr.Field<string>("OfficePhoneNumber");

                        results.Add(obj);
                    }
                }

                return results;
            }

            public static List<SourceObject> updateSourceObject(object request)
            {
                SourceObject obj = new SourceObject();
                List<SourceObject> results = new List<SourceObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Source_Update", _connection);
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
                        obj = new SourceObject();
                        obj.PK_Source_Id = dr.Field<int>("PK_Source_Id");
                        obj.Source_Name = dr.Field<string>("Source_Name");
                        obj.SourceDescription = dr.Field<string>("SourceDescription");
                        obj.AddressStreet = dr.Field<string>("AddressStreet");
                        obj.AddressUnit = dr.Field<string>("AddressUnit");
                        obj.AddressCity = dr.Field<string>("AddressCity");
                        obj.AddressState = dr.Field<string>("AddressState");
                        obj.AddressZip = dr.Field<string>("AddressZip");
                        obj.IsActive = dr.Field<bool>("IsActive");
                        obj.IsDeleted = dr.Field<bool>("IsDeleted");
                        obj.OfficePhoneNumber = dr.Field<string>("OfficePhoneNumber");
                        obj.OfficeEmailAddress = dr.Field<string>("OfficeEmailAddress");
                        results.Add(obj);
                    }
                }

                return results;
            }

            public static SourceObjectRow createSourceObject(object request)
            {
                SourceObjectRow obj = new SourceObjectRow();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Source_Create", _connection);
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
                        obj.PK_Source_Id = dr.Field<int>("PK_Source_Id");
                        obj.Source_Name = dr.Field<string>("Source_Name");
                        obj.SourceDescription = dr.Field<string>("SourceDescription");
                        obj.AddressStreet = dr.Field<string>("AddressStreet");
                        obj.AddressUnit = dr.Field<string>("AddressUnit");
                        obj.AddressCity = dr.Field<string>("AddressCity");
                        obj.AddressState = dr.Field<string>("AddressState");
                        obj.AddressZip = dr.Field<string>("AddressZip");
                        obj.IsActive = dr.Field<bool>("IsActive");
                        obj.IsDeleted = dr.Field<bool>("IsDeleted");
                        obj.OfficePhoneNumber = dr.Field<string>("OfficePhoneNumber");
                        obj.OfficeEmailAddress = dr.Field<string>("OfficeEmailAddress");
                    }
                }

                return obj;
            }

            public static List<SourceObject> deleteSourceObject(object request)
            {
                SourceObject obj = new SourceObject();
                List<SourceObject> results = new List<SourceObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Source_Delete", _connection);
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.CommandTimeout = 120;
                scmd.Parameters.Add(new SqlParameter("@Request", JsonConvert.SerializeObject(request)));
                _connection.Open();
                scmd.ExecuteNonQuery();
                return results;
            }


        }
    }

}
