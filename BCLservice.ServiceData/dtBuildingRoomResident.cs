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
        public class dtBuildingRoomResident
        {
            private string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            private SqlConnection _connection;

            public dtBuildingRoomResident()
            {

            }

            
            public static List<BuildingRoomResidentObject> returnBuildingRoomResidentObject(int FK_Building_Id)
            {
                BuildingRoomResidentObject obj = new BuildingRoomResidentObject();
                List<BuildingRoomResidentObject> results = new List<BuildingRoomResidentObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_BuildingRoomResident_Select", _connection);
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.CommandTimeout = 31;
                scmd.Parameters.Add(new SqlParameter("@FK_Building_Id", FK_Building_Id));
                DataTable dt = new DataTable();
                SqlDataAdapter td = new SqlDataAdapter(scmd);
                _connection.Open();
                td.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj = new BuildingRoomResidentObject();
                        obj.PK_RoomResident_Id = dr.Field<int>("PK_RoomResident_Id");
                        obj.FK_Resident_Id = dr.Field<int>("FK_Resident_Id");
                        obj.FK_BuildingRoom_Id = dr.Field<int>("FK_BuildingRoom_Id");
                        obj.RentPaymentFrequency = dr.Field<string>("RentPaymentFrequency");
                        obj.RentPaymentAmount = dr.Field<decimal>("RentPaymentAmount");
                        obj.EffectiveDate = dr.Field<DateTime>("EffectiveDate");
                        obj.TerminationDate = dr.Field<DateTime>("TerminationDate");
                        obj.IsActive = dr.Field<bool>("IsActive");
                        obj.IsDeleted = dr.Field<bool>("IsDeleted");
                        results.Add(obj);
                    }
                }

                return results;
            }

            public static List<BuildingRoomResidentObject> updateBuildingRoomResidentObject(object request)
            {
                BuildingRoomResidentObject obj = new BuildingRoomResidentObject();
                List<BuildingRoomResidentObject> results = new List<BuildingRoomResidentObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_BuildingRoomResident_Update", _connection);
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
                        obj = new BuildingRoomResidentObject();
                        obj.PK_RoomResident_Id = dr.Field<int>("PK_RoomResident_Id");
                        obj.FK_Resident_Id = dr.Field<int>("FK_Resident_Id");
                        obj.FK_BuildingRoom_Id = dr.Field<int>("FK_BuildingRoom_Id");
                        obj.RentPaymentFrequency = dr.Field<string>("RentPaymentFrequency");
                        obj.RentPaymentAmount = dr.Field<decimal>("RentPaymentAmount");
                        obj.IsActive = dr.Field<bool>("IsActive");
                        obj.IsDeleted = dr.Field<bool>("IsDeleted");
                        results.Add(obj);
                    }
                }

                return results;
            }

            public static BuildingRoomResidentObjectRow createBuildingRoomResidentObject(object request)
            {
                BuildingRoomResidentObjectRow obj = new BuildingRoomResidentObjectRow();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_BuildingRoomResident_Create", _connection);
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
                        obj.PK_RoomResident_Id = dr.Field<int>("PK_RoomResident_Id");
                        obj.FK_Resident_Id = dr.Field<int>("FK_Resident_Id");
                        obj.FK_BuildingRoom_Id = dr.Field<int>("FK_BuildingRoom_Id");
                        obj.RentPaymentFrequency = dr.Field<string>("RentPaymentFrequency");
                        obj.RentPaymentAmount = dr.Field<decimal>("RentPaymentAmount");
                        obj.IsActive = dr.Field<bool>("IsActive");
                        obj.IsDeleted = dr.Field<bool>("IsDeleted");
                    }
                }

                return obj;
            }

            public static List<BuildingRoomResidentObject> deleteBuildingRoomResidentObject(object request)
            {
                BuildingRoomResidentObject obj = new BuildingRoomResidentObject();
                List<BuildingRoomResidentObject> results = new List<BuildingRoomResidentObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("BCL_BuildingRoomResident_Delete", _connection);
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
