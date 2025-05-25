using System;
using System.Collections.Generic;
using ServiceStack;
using BCLservice.ServiceData;


namespace BCLservice.ServiceModel
{
    [Route("/jTable/NopSource")]
    public class jTableNOPSource_Request : SourceObjectRow, IReturn<jSourceResponse>
    {

    }

    [Route("/SourceSelect")]
    public class SourceSelect_Request : IReturn<SourceResponse>
    {
    }

    public class SourceResponse : IHasResponseStatus
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
        private List<SourceObject> _Source;
        public List<SourceObject> Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
            }
        }
        public SourceResponse()
        {
            this.Source = new List<SourceObject>();
            this.ResponseStatus = new ResponseStatus();
            this.ResponseStatus.Errors = new List<ResponseError>();
        }
    }

    [Route("/jTable/SourceSelect")]
    public class jSourceSelect_Request : IReturn<jSourceResponse>
    {
    }

    [Route("/jTable/SourceUpdate")]
    public class jSourceUpdate_Request : SourceObjectRow, IReturn<jSourceResponse>
    {

    }

    [Route("/jTable/SourceDelete")]
    public class jSourceDelete_Request : SourceObjectRow, IReturn<jSourceResponse>
    {

    }

    [Route("/jTable/SourceCreate")]
    public class jSourceCreate_Request : SourceObjectRow, IReturn<jSourceRecordResponse>
    {

    }

    public class jSourceRecordResponse
    {
        public string Result { get; set; }
        public SourceObjectRow Record { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Record = new SourceObjectRow();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

    public class jSourceResponse
    {
        public string Result { get; set; }
        public List<SourceObject> Records { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Records = new List<SourceObject>();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

}

