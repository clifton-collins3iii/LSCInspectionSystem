using System;
using System.Collections.Generic;
using ServiceStack;
using LSCservice.ServiceData;


namespace LSCservice.ServiceModel
{
    [Route("/jTable/NopResident")]
    public class jTableNOPResident_Request : ResidentObjectRow, IReturn<jResidentResponse>
    {

    }

    [Route("/ResidentSelect")]
    public class ResidentSelect_Request : IReturn<ResidentResponse>
    {
    }

    public class ResidentResponse : IHasResponseStatus
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
        private List<ResidentObject> _Resident;
        public List<ResidentObject> Resident
        {
            get
            {
                return _Resident;
            }
            set
            {
                _Resident = value;
            }
        }
        public ResidentResponse()
        {
            this.Resident = new List<ResidentObject>();
            this.ResponseStatus = new ResponseStatus();
            this.ResponseStatus.Errors = new List<ResponseError>();
        }
    }

    [Route("/jTable/ResidentSelect")]
    public class jResidentSelect_Request : IReturn<jResidentResponse>
    {
    }

    [Route("/jTable/ResidentUpdate")]
    public class jResidentUpdate_Request : ResidentObjectRow, IReturn<jResidentResponse>
    {

    }

    [Route("/jTable/ResidentDelete")]
    public class jResidentDelete_Request : ResidentObjectRow, IReturn<jResidentResponse>
    {

    }

    [Route("/jTable/ResidentCreate")]
    public class jResidentCreate_Request : ResidentObjectRow, IReturn<jResidentRecordResponse>
    {

    }

    public class jResidentRecordResponse
    {
        public string Result { get; set; }
        public ResidentObjectRow Record { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Record = new ResidentObjectRow();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

    public class jResidentResponse
    {
        public string Result { get; set; }
        public List<ResidentObject> Records { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Records = new List<ResidentObject>();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

}

