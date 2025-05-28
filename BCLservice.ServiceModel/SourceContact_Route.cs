using System;
using System.Collections.Generic;
using ServiceStack;
using LSCservice.ServiceData;

namespace LSCservice.ServiceModel
{
    [Route("/jTable/NopSourceContact")]
    public class jTableNOPSourceContact_Request : SourceContactObjectRow, IReturn<jSourceContactResponse>
    {

    }

    [Route("/SourceContactSelect")]
    public class SourceContactSelect_Request : IReturn<jSourceContactResponse>
    {
    }

    public class SourceContactResponse : IHasResponseStatus
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
        private List<SourceContactObject> _Contact;
        public List<SourceContactObject> SourceContact
        {
            get
            {
                return _Contact;
            }
            set
            {
                _Contact = value;
            }
        }
        public SourceContactResponse()
        {
            this.SourceContact = new List<SourceContactObject>();
            this.ResponseStatus = new ResponseStatus();
            this.ResponseStatus.Errors = new List<ResponseError>();
        }
    }

    [Route("/jTable/SourceContactSelect")]
    public class jSourceContactSelect_Request : IReturn<jSourceContactResponse>
    {
    }

    [Route("/jTable/SourceContactUpdate")]
    public class jSourceContactUpdate_Request : SourceContactObjectRow, IReturn<jSourceContactResponse>
    {

    }

    [Route("/jTable/SourceContactDelete")]
    public class jSourceContactDelete_Request : SourceContactObjectRow, IReturn<jSourceContactResponse>
    {

    }

    [Route("/jTable/SourceContactCreate")]
    public class jSourceContactCreate_Request : SourceContactObjectRow, IReturn<jSourceContactRecordResponse>
    {

    }

    public class jSourceContactRecordResponse
    {
        public string Result { get; set; }
        public SourceContactObjectRow Record { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Record = new SourceContactObjectRow();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

    public class jSourceContactResponse
    {
        public string Result { get; set; }
        public List<SourceContactObject> Records { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Records = new List<SourceContactObject>();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

}

