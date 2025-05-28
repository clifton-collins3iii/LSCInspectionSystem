using LSCservice.ServiceData;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSCservice.ServiceData.BCLservice.ServiceData;

namespace LSCservice.ServiceInterface
{
    public class Contact_Service : Service
    {
        public object Any(ServiceModel.jTableNOPContact_Request request)
        {
            ServiceModel.jContactResponse result = new ServiceModel.jContactResponse();
            result.Result = "ERROR";
            try
            {
                ContactObject brow = new ContactObject();
                brow.PK_Contact_Id = 0;
                List<ContactObject> bobj = new List<ContactObject>();
                bobj.Add(brow);
                result.Records = bobj;
                result.TotalRecordCount = 0;
                result.Result = "ERROR";
                result.Message = "User CANCELLED the action.\r\nNothing changed/deleted";
            }
            catch (Exception ex)
            {
                result.Result = "ERROR";
                result.Message = ex.Message;
            }
            return result;
        }

        public object Any(ServiceModel.ContactSelect_Request request)
        {
            ServiceModel.ContactResponse result = new ServiceModel.ContactResponse();
            ResponseStatus status = new ResponseStatus
            {
                ErrorCode = "Success",
                Message = request.ToString()
            };
            result.Contact = dtContact.returnContactObject();
            return result;
        }

        public object Any(ServiceModel.jContactSelect_Request request)
        {
            ServiceModel.jContactResponse result = new ServiceModel.jContactResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtContact.returnContactObject();
                result.TotalRecordCount = result.Records.Count;
                result.Result = "OK";
                result.Message = "";
            }
            catch (Exception ex)
            {
                result.Result = "ERROR";
                result.Message = ex.Message;
            }
            return result;
        }

        public object Any(ServiceModel.jContactUpdate_Request request)
        {
            ServiceModel.jContactResponse result = new ServiceModel.jContactResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtContact.updateContactObject(request);
                result.TotalRecordCount = result.Records.Count;
                result.Result = "OK";
                result.Message = "";
            }
            catch (Exception ex)
            {
                result.Result = "ERROR";
                result.Message = ex.Message;
            }
            return result;
        }

        public object Any(ServiceModel.jContactCreate_Request request)
        {
            ServiceModel.jContactRecordResponse result = new ServiceModel.jContactRecordResponse();
            result.Result = "ERROR";
            try
            {
                result.Record = dtContact.createContactObject(request);
                result.TotalRecordCount = 1;
                result.Result = "OK";
                result.Message = "";
            }
            catch (Exception ex)
            {
                result.Result = "ERROR";
                result.Message = ex.Message;
            }
            return result;
        }

        public object Any(ServiceModel.jContactDelete_Request request)
        {
            ServiceModel.jContactResponse result = new ServiceModel.jContactResponse();
            result.Result = "ERROR";
            try
            {
                dtContact.deleteContactObject(request);
                //result.TotalRecordCount = result.Records.Count;
                result.Result = "OK";
                result.Message = "";
            }
            catch (Exception ex)
            {
                result.Result = "ERROR";
                result.Message = ex.Message;
            }
            return result;
        }

    }
}
