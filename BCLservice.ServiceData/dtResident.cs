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
        public class dtResident
        {
            private string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            private SqlConnection _connection;

            public dtResident()
            {

            }

            
            public static List<ResidentObject> returnResidentObject()
            {
                ResidentObject obj = new ResidentObject();
                List<ResidentObject> results = new List<ResidentObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Resident_Select", _connection);
                DataTable dt = new DataTable();
                SqlDataAdapter td = new SqlDataAdapter(scmd);
                _connection.Open();
                td.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj = new ResidentObject();
                        obj.PK_Resident_Id = dr.Field<int>("PK_Resident_Id");
                        obj.Name_First = dr.Field<string>("Name_First");
                        obj.Name_Middle = dr.Field<string>("Name_Middle");
                        obj.Name_Second = dr.Field<string>("Name_Second");
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

            public static List<ResidentObject> updateResidentObject(object request)
            {
                ResidentObject obj = new ResidentObject();
                List<ResidentObject> results = new List<ResidentObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Resident_Update", _connection);
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.CommandTimeout = 120;
                scmd.Parameters.Add( new SqlParameter("@Request", JsonConvert.SerializeObject(request)));
                DataTable dt = new DataTable();
                SqlDataAdapter td = new SqlDataAdapter(scmd);
                _connection.Open();
                td.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj = new ResidentObject();
                        obj.PK_Resident_Id = dr.Field<int>("PK_Resident_Id");
                        obj.Name_First = dr.Field<string>("Name_First");
                        obj.Name_Middle = dr.Field<string>("Name_Middle");
                        obj.Name_Second = dr.Field<string>("Name_Second");
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

            public static ResidentObjectRow createResidentObject(object request)
            {
                ResidentObjectRow obj = new ResidentObjectRow();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Resident_Create", _connection);
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
                        obj.PK_Resident_Id = dr.Field<int>("PK_Resident_Id");
                        obj.Name_First = dr.Field<string>("Name_First");
                        obj.Name_Middle = dr.Field<string>("Name_Middle");
                        obj.Name_Second = dr.Field<string>("Name_Second");
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

            public static List<ResidentObject> deleteResidentObject(object request)
            {
                ResidentObject obj = new ResidentObject();
                List<ResidentObject> results = new List<ResidentObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Resident_Delete", _connection);
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
