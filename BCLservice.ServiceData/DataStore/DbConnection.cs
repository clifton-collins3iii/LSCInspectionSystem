using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BCLservice.DataStore
{
    public class BclDbConnection
    {
        private string _connectionstring = ConfigurationManager.ConnectionStrings["BCLservice.Properties.Settings.dbconnection"].ConnectionString;
        private SqlConnection _connection;
        public SqlConnection Connection {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
            }
        }
        public string ConnectionString
        {
            get
            {
                return _connectionstring;
            }
        }

        public SqlConnection  DbOpen()
        {
            _connection = new SqlConnection( _connectionstring);
            _connection.Open();
            return _connection;                     //DbOpen(_connectionstring);
        }

        public SqlConnection DbOpen(string sqlconnectionstring)
        {
            if (_connection != null && _connection.State != ConnectionState.Open) {
                _connectionstring = sqlconnectionstring;
                _connection = new SqlConnection(_connectionstring);
                _connection.Open();
            }
            return _connection;
        }

        public bool DbClose()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
            return true;
        }
    }
}
