using System;
using System.Collections.Generic;
using ServiceStack;
using BCLservice.ServiceData;

namespace BCLservice.ServiceModel
{
    [Route("/jTable/NopCampus")]
    public class jTableNOPCampus_Request : CampusObjectRow, IReturn<jCampusResponse>
    {

    }

    [Route("/CampusSelect")]
    public class CampusSelect_Request : IReturn<CampusResponse>
    {
    }

    public class CampusResponse : IHasResponseStatus
    {
        private ResponseStatus _responseStatus;
        public ResponseStatus ResponseStatus
        {
            get
            {
                return _responseStatus;
            }
            set
            {
                _responseStatus = value;
            }
        }
        private List<CampusObject> _Campus;
        public List<CampusObject> Campus
        {
            get
            {
                return _Campus;
            }
            set
            {
                _Campus = value;
            }
        }
        public CampusResponse()
        {
            this.Campus = new List<CampusObject>();
            this.ResponseStatus = new ResponseStatus();
            this.ResponseStatus.Errors = new List<ResponseError>();
        }
    }

    [Route("/jTable/CampusSelect")]
    public class jCampusSelect_Request : IReturn<jCampusResponse>
    {
    }

    [Route("/jTable/CampusUpdate")]
    public class jCampusUpdate_Request : CampusObjectRow, IReturn<jCampusResponse>
    {

    }

    [Route("/jTable/CampusDelete")]
    public class jCampusDelete_Request : CampusObjectRow, IReturn<jCampusResponse>
    {

    }

    [Route("/jTable/CampusCreate")]
    public class jCampusCreate_Request : CampusObjectRow, IReturn<jCampusRecordResponse>
    {

    }

    public class jCampusRecordResponse
    {
        public string Result { get; set; }
        public CampusObjectRow Record { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Record = new CampusObjectRow();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

    public class jCampusResponse
    {
        public string Result { get; set; }
        public List<CampusObject> Records { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Records = new List<CampusObject>();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }


}
