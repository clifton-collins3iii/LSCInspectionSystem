using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LSCservice.ServiceData
{
    using System.Data;
    using System.Net.NetworkInformation;
    using System.Data.SqlClient;
    using System.Configuration;
    using global::LSCservice.DataStore;

    public class dtTableOptions_Services
    {
        private string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
        private SqlConnection _connection;

        public dtTableOptions_Services()
        {

        }

        public static List<jTableOptionsObject> returnBuildingOptionsObject()
        {
            jTableOptionsObject obj = new jTableOptionsObject();
            List<jTableOptionsObject> results = new List<jTableOptionsObject>();
            obj.Value = 0;
            obj.DisplayText = "Select a Building";
            results.Add(obj);
            string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(_connectionstring);
            BclDbConnection conn = new BclDbConnection();
            SqlCommand scmd = new SqlCommand("BCL_BuildingOptions_Select", _connection);
            DataTable dt = new DataTable();
            SqlDataAdapter td = new SqlDataAdapter(scmd);
            _connection.Open();
            td.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new jTableOptionsObject();
                    obj.Value = dr.Field<int>("PK_Building_Id");
                    obj.DisplayText = dr.Field<string>("Name_Short");
                    results.Add(obj);
                }
            }
            return results;
        }

        public static List<jTableStrOptionsObject> returnStatesOptionsObject()
        {
            jTableStrOptionsObject obj = new jTableStrOptionsObject();
            List<jTableStrOptionsObject> results = new List<jTableStrOptionsObject>();
            obj.Value = "0";
            obj.DisplayText = "Select a State";
            results.Add(obj);
            string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(_connectionstring);
            BclDbConnection conn = new BclDbConnection();
            SqlCommand scmd = new SqlCommand("BCL_StateOptions_Select", _connection);
            DataTable dt = new DataTable();
            SqlDataAdapter td = new SqlDataAdapter(scmd);
            _connection.Open();
            td.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new jTableStrOptionsObject();
                    obj.Value = dr.Field<string>("StateAbbr");
                    obj.DisplayText = dr.Field<string>("State");
                    results.Add(obj);
                }
            }
            return results;
        }

        public static List<jTableStrOptionsObject> returnRentPaymentFrequencyOptionsObject()
        {
            jTableStrOptionsObject obj = new jTableStrOptionsObject();
            List<jTableStrOptionsObject> results = new List<jTableStrOptionsObject>();
            string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(_connectionstring);
            BclDbConnection conn = new BclDbConnection();
            SqlCommand scmd = new SqlCommand("BCL_PaymentFrequencyOptions_Select", _connection);
            DataTable dt = new DataTable();
            SqlDataAdapter td = new SqlDataAdapter(scmd);
            _connection.Open();
            td.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new jTableStrOptionsObject();
                    obj.Value = dr.Field<string>("Name_Short");
                    obj.DisplayText = dr.Field<string>("Name_Short");
                    results.Add(obj);
                }
            }
            return results;
        }

        public static List<jTableOptionsObject> returnResidentOptionsObject()
        {
            jTableOptionsObject obj = new jTableOptionsObject();
            List<jTableOptionsObject> results = new List<jTableOptionsObject>();
            obj.Value = 0;
            obj.DisplayText = "Vacant";
            results.Add(obj);
            string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(_connectionstring);
            BclDbConnection conn = new BclDbConnection();
            SqlCommand scmd = new SqlCommand("BCL_ResidentOptions_Select", _connection);
            DataTable dt = new DataTable();
            SqlDataAdapter td = new SqlDataAdapter(scmd);
            _connection.Open();
            td.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new jTableOptionsObject();
                    obj.Value = dr.Field<int>("PK_Resident_Id");
                    obj.DisplayText = dr.Field<string>("ResidentName");
                    results.Add(obj);
                }
            }
            return results;
        }

        public static List<jTableOptionsObject> returnRoomOptionsObject(string PK_Building_Id)
        {
            jTableOptionsObject obj = new jTableOptionsObject();
            List<jTableOptionsObject> results = new List<jTableOptionsObject>();
            obj.Value = 0;
            obj.DisplayText = "None";
            string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(_connectionstring);
            BclDbConnection conn = new BclDbConnection();
            SqlCommand scmd = new SqlCommand("BCL_RoomOptions_Select", _connection);
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandTimeout = 120;
            scmd.Parameters.Add(new SqlParameter("@PK_Building_Id", PK_Building_Id));
            DataTable dt = new DataTable();
            SqlDataAdapter td = new SqlDataAdapter(scmd);
            _connection.Open();
            td.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new jTableOptionsObject();
                    obj.Value = dr.Field<int>("PK_BuildingRoom_Id");
                    obj.DisplayText = dr.Field<string>("Name_Short");
                    results.Add(obj);
                }
            }
            return results;
        }

        public static List<jTableOptionsObject> returnContactOptionsObject(string PK_Source_Id)
        {
            jTableOptionsObject obj = new jTableOptionsObject();
            List<jTableOptionsObject> results = new List<jTableOptionsObject>();
            obj.Value = 0;
            obj.DisplayText = "None";
            string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(_connectionstring);
            BclDbConnection conn = new BclDbConnection();
            SqlCommand scmd = new SqlCommand("BCL_ContactOptions_Select", _connection);
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandTimeout = 120;
            scmd.Parameters.Add(new SqlParameter("@PK_Source_Id", PK_Source_Id));
            DataTable dt = new DataTable();
            SqlDataAdapter td = new SqlDataAdapter(scmd);
            _connection.Open();
            td.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new jTableOptionsObject();
                    obj.Value = dr.Field<int>("PK_SourceContact_Id");
                    obj.DisplayText = dr.Field<string>("ContactName");
                    results.Add(obj);
                }
            }
            return results;
        }
    }
}
