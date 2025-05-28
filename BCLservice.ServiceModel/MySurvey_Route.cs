using System;
using System.Collections.Generic;
using ServiceStack;
using LSCservice.ServiceData;


namespace LSCservice.ServiceModel
{
    [Route("/jTable/NopMySurvey")]
    public class jTableNOPMySurvey_Request : MySurveyObjectRow, IReturn<jMySurveyResponse>
    {

    }

    [Route("/MySurveySelect")]
    public class MySurveySelect_Request : IReturn<MySurveyResponse>
    {
    }

    public class MySurveyResponse : IHasResponseStatus
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
        private List<MySurveyObject> _MySurvey;
        public List<MySurveyObject> MySurvey
        {
            get
            {
                return _MySurvey;
            }
            set
            {
                _MySurvey = value;
            }
        }
        public MySurveyResponse()
        {
            this.MySurvey = new List<MySurveyObject>();
            this.ResponseStatus = new ResponseStatus();
            this.ResponseStatus.Errors = new List<ResponseError>();
        }
    }

    [Route("/jTable/MySurveySelect")]
    public class jMySurveySelect_Request : IReturn<jMySurveyResponse>
    {
    }

    [Route("/jTable/MySurveyUpdate")]
    public class jMySurveyUpdate_Request : MySurveyObjectRow, IReturn<jMySurveyResponse>
    {

    }

    [Route("/jTable/MySurveyDelete")]
    public class jMySurveyDelete_Request : MySurveyObjectRow, IReturn<jMySurveyResponse>
    {

    }

    [Route("/jTable/MySurveyCreate")]
    public class jMySurveyCreate_Request : MySurveyObjectRow, IReturn<jMySurveyRecordResponse>
    {

    }

    public class jMySurveyRecordResponse
    {
        public string Result { get; set; }
        public MySurveyObjectRow Record { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Record = new MySurveyObjectRow();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

    public class jMySurveyResponse
    {
        public string Result { get; set; }
        public List<MySurveyObject> Records { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Records = new List<MySurveyObject>();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

}

