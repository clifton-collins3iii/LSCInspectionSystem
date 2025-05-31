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
        public class dtMySurvey
        {
            private string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
            private SqlConnection _connection;

            public dtMySurvey()
            {

            }


            public static List<MySurveyObject> returnMySurveyObject()
            {
                MySurveyObject obj = new MySurveyObject();
                List<MySurveyObject> results = new List<MySurveyObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("LSC_MySurvey_Select", _connection);
                DataTable dt = new DataTable();
                SqlDataAdapter td = new SqlDataAdapter(scmd);
                _connection.Open();
                td.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj = new MySurveyObject();
                        obj.PK_InspectionSurvey_Id = dr.Field<int>("PK_InspectionSurvey_Id");
                        obj.TemplateName = dr.Field<string>("TemplateName");
                        obj.CampusName = dr.Field<string>("CampusName");
                        obj.UserName = dr.Field<string>("UserName");
                        obj.CreatedDate = dr.Field<DateTime>("CreatedDate");
                        obj.SubmittedDate = dr.Field<DateTime>("SubmittedDate");
                        obj.ReviewedDate = dr.Field<DateTime>("ReviewedDate");

                        results.Add(obj);
                    }
                }

                return results;
            }

            public static List<MySurveyObject> updateMySurveyObject(object request)
            {
                MySurveyObject obj = new MySurveyObject();
                List<MySurveyObject> results = new List<MySurveyObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("LSC_MySurvey_Update", _connection);
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
                        obj = new MySurveyObject();
                        obj.PK_InspectionSurvey_Id = dr.Field<int>("PK_InspectionSurvey_Id");
                        obj.TemplateName = dr.Field<string>("TemplateName");
                        obj.CampusName = dr.Field<string>("CampusName");
                        obj.UserName = dr.Field<string>("UserName");
                        obj.CreatedDate = dr.Field<DateTime>("CreatedDate");
                        obj.SubmittedDate = dr.Field<DateTime>("SubmittedDate");
                        obj.ReviewedDate = dr.Field<DateTime>("ReviewedDate");
                        results.Add(obj);
                    }
                }

                return results;
            }

            public static MySurveyObjectRow createMySurveyObject(object request)
            {
                MySurveyObjectRow obj = new MySurveyObjectRow();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("LSC_MySurvey_Create", _connection);
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
                        obj.PK_InspectionSurvey_Id = dr.Field<int>("PK_InspectionSurvey_Id");
                        obj.TemplateName = dr.Field<string>("TemplateName");
                        obj.CampusName = dr.Field<string>("CampusName");
                        obj.UserName = dr.Field<string>("UserName");
                        obj.CreatedDate = dr.Field<DateTime>("CreatedDate");
                        obj.SubmittedDate = dr.Field<DateTime>("SubmittedDate");
                        obj.ReviewedDate = dr.Field<DateTime>("ReviewedDate");
                    }
                }

                return obj;
            }

            public static List<MySurveyObject> deleteMySurveyObject(object request)
            {
                MySurveyObject obj = new MySurveyObject();
                List<MySurveyObject> results = new List<MySurveyObject>();
                string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
                SqlConnection _connection = new SqlConnection(_connectionstring);
                BclDbConnection conn = new BclDbConnection();
                SqlCommand scmd = new SqlCommand("LSC_MySurvey_Delete", _connection);
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
