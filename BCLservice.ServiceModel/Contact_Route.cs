using System;
using System.Collections.Generic;
using ServiceStack;
using BCLservice.ServiceData;


namespace BCLservice.ServiceModel
{
    [Route("/jTable/NopContact")]
    public class jTableNOPContact_Request : ContactObjectRow, IReturn<jContactResponse>
    {

    }

    [Route("/ContactSelect")]
    public class ContactSelect_Request : IReturn<ContactResponse>
    {
    }

    public class ContactResponse : IHasResponseStatus
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
        private List<ContactObject> _Contact;
        public List<ContactObject> Contact
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
        public ContactResponse()
        {
            this.Contact = new List<ContactObject>();
            this.ResponseStatus = new ResponseStatus();
            this.ResponseStatus.Errors = new List<ResponseError>();
        }
    }

    [Route("/jTable/ContactSelect")]
    public class jContactSelect_Request : IReturn<jContactResponse>
    {
    }

    [Route("/jTable/ContactUpdate")]
    public class jContactUpdate_Request : ContactObjectRow, IReturn<jContactResponse>
    {

    }

    [Route("/jTable/ContactDelete")]
    public class jContactDelete_Request : ContactObjectRow, IReturn<jContactResponse>
    {

    }

    [Route("/jTable/ContactCreate")]
    public class jContactCreate_Request : ContactObjectRow, IReturn<jContactRecordResponse>
    {

    }

    public class jContactRecordResponse
    {
        public string Result { get; set; }
        public ContactObjectRow Record { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Record = new ContactObjectRow();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

    public class jContactResponse
    {
        public string Result { get; set; }
        public List<ContactObject> Records { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Records = new List<ContactObject>();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

}

