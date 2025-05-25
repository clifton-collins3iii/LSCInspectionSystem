using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLservice.ServiceData
{
    public class AppVersionObject
    {
        public AppVersionObject()
        {
        }
        private Int32 _pk_id;
        private string _versionstring;
        private DateTime _effective_date;

        public Int32 pk_id
        {
            get
            {
                return _pk_id;
            }
            set
            {
                _pk_id = value;
            }
        }
        public DateTime created_date { get; set; }

        public DateTime effective_date
        {
            get
            {
                return _effective_date;
            }
            set
            {
                _effective_date = value;
            }
        }

        public string DBName { get; set; }
        public string SQLServerName { get; set; }

        public string SQLSVRversion { get; set; }
        public string versionstring
        {
            get
            {
                return _versionstring;
            }
            set
            {
                _versionstring = value;
            }
        }
        public int version_id { get; set; }
        public string version_number { get; set; }
    }

}
