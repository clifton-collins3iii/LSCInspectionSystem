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
using global::LSCservice.DataStore;

namespace LSCservice.ServiceData
{
    
    namespace BCLservice.ServiceData
    {
        public class dtBuilding
        {
            private string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            private SqlConnection _connection;

            public dtBuilding()
            {

            }

            
            public static List<BuildingObject> returnBuildingObject()
            {
                BuildingObject obj = new BuildingObject();
                List<BuildingObject> results = new List<BuildingObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Building_Select", _connection);
                DataTable dt = new DataTable();
                SqlDataAdapter td = new SqlDataAdapter(scmd);
                _connection.Open();
                td.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj = new BuildingObject();
                        obj.PK_Building_Id = dr.Field<int>("PK_Building_Id");
                        obj.FK_Campus_Id = dr.Field<int>("FK_Campus_Id");
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

            public static List<BuildingObject> updateBuildingObject(object request)
            {
                BuildingObject obj = new BuildingObject();
                List<BuildingObject> results = new List<BuildingObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Building_Update", _connection);
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
                        obj = new BuildingObject();
                        obj.PK_Building_Id = dr.Field<int>("PK_Building_Id");
                        obj.FK_Campus_Id = dr.Field<int>("FK_Campus_Id");
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

            public static BuildingObjectRow createBuildingObject(object request)
            {
                BuildingObjectRow obj = new BuildingObjectRow();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Building_Create", _connection);
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
                        obj.PK_Building_Id = dr.Field<int>("PK_Building_Id");
                        obj.FK_Campus_Id = dr.Field<int>("FK_Campus_Id");
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

            public static List<BuildingObject> deleteBuildingObject(object request)
            {
                BuildingObject obj = new BuildingObject();
                List<BuildingObject> results = new List<BuildingObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_Building_Delete", _connection);
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
