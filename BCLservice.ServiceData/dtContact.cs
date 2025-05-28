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
        public class dtContact
        {
            private string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            private SqlConnection _connection;

            public dtContact()
            {

            }


            public static List<ContactObject> returnContactObject()
            {
                ContactObject obj = new ContactObject();
                List<ContactObject> results = new List<ContactObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Contact_Select", _connection);
                DataTable dt = new DataTable();
                SqlDataAdapter td = new SqlDataAdapter(scmd);
                _connection.Open();
                td.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj = new ContactObject();
                        obj.PK_Contact_Id = dr.Field<int>("PK_Contact_Id");
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

            public static List<ContactObject> updateContactObject(object request)
            {
                ContactObject obj = new ContactObject();
                List<ContactObject> results = new List<ContactObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Contact_Update", _connection);
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
                        obj = new ContactObject();
                        obj.PK_Contact_Id = dr.Field<int>("PK_Contact_Id");
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

            public static ContactObjectRow createContactObject(object request)
            {
                ContactObjectRow obj = new ContactObjectRow();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Contact_Create", _connection);
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
                        obj.PK_Contact_Id = dr.Field<int>("PK_Contact_Id");
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

            public static List<ContactObject> deleteContactObject(object request)
            {
                ContactObject obj = new ContactObject();
                List<ContactObject> results = new List<ContactObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Contact_Delete", _connection);
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
