using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BCLservice.ServiceData
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
    using global::BCLservice.DataStore;

    namespace BCLservice.ServiceData
    {
        public class dtBuildingRoom
        {
            private string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            private SqlConnection _connection;

            public dtBuildingRoom()
            {

            }

            
            public static List<BuildingRoomObject> returnBuildingRoomObject()
            {
                BuildingRoomObject obj = new BuildingRoomObject();
                List<BuildingRoomObject> results = new List<BuildingRoomObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_BuildingRoom_Select", _connection);
                DataTable dt = new DataTable();
                SqlDataAdapter td = new SqlDataAdapter(scmd);
                _connection.Open();
                td.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj = new BuildingRoomObject();
                        obj.PK_BuildingRoom_Id = dr.Field<int>("PK_BuildingRoom_Id");
                        obj.FK_Building_Id = dr.Field<int>("FK_Building_Id");
                        obj.Name_Short = dr.Field<string>("Name_Short");
                        obj.Name_Long = dr.Field<string>("Name_Long");
                        obj.Description = dr.Field<string>("Description");
                        obj.RentPaymentFrequency = dr.Field<string>("RentPaymentFrequency");
                        obj.RentPaymentAmount = dr.Field<decimal>("RentPaymentAmount");
                        obj.IsActive = dr.Field<bool>("IsActive");
                        obj.IsDeleted = dr.Field<bool>("IsDeleted");
                        results.Add(obj);
                    }
                }

                return results;
            }

            public static List<BuildingRoomObject> updateBuildingRoomObject(object request)
            {
                BuildingRoomObject obj = new BuildingRoomObject();
                List<BuildingRoomObject> results = new List<BuildingRoomObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_BuildingRoom_Update", _connection);
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
                        obj = new BuildingRoomObject();
                        obj.PK_BuildingRoom_Id = dr.Field<int>("PK_BuildingRoom_Id");
                        obj.FK_Building_Id = dr.Field<int>("FK_Building_Id");
                        obj.Name_Short = dr.Field<string>("Name_Short");
                        obj.Name_Long = dr.Field<string>("Name_Long");
                        obj.Description = dr.Field<string>("Description");
                        obj.RentPaymentFrequency = dr.Field<string>("RentPaymentFrequency");
                        obj.RentPaymentAmount = dr.Field<decimal>("RentPaymentAmount");
                        obj.IsActive = dr.Field<bool>("IsActive");
                        obj.IsDeleted = dr.Field<bool>("IsDeleted");
                        results.Add(obj);
                    }
                }

                return results;
            }

            public static BuildingRoomObjectRow createBuildingRoomObject(object request)
            {
                BuildingRoomObjectRow obj = new BuildingRoomObjectRow();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_BuildingRoom_Create", _connection);
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
                        obj.PK_BuildingRoom_Id = dr.Field<int>("PK_BuildingRoom_Id");
                        obj.FK_Building_Id = dr.Field<int>("FK_Building_Id");
                        obj.Name_Short = dr.Field<string>("Name_Short");
                        obj.Name_Long = dr.Field<string>("Name_Long");
                        obj.Description = dr.Field<string>("Description");
                        obj.RentPaymentFrequency = dr.Field<string>("RentPaymentFrequency");
                        obj.RentPaymentAmount = dr.Field<decimal>("RentPaymentAmount");
                        obj.IsActive = dr.Field<bool>("IsActive");
                        obj.IsDeleted = dr.Field<bool>("IsDeleted");
                    }
                }

                return obj;
            }

            public static List<BuildingRoomObject> deleteBuildingRoomObject(object request)
            {
                BuildingRoomObject obj = new BuildingRoomObject();
                List<BuildingRoomObject> results = new List<BuildingRoomObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_BuildingRoom_Delete", _connection);
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
