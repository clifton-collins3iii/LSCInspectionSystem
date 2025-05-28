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
    public class Source_Service : Service
    {
        public object Any(ServiceModel.jTableNOPSource_Request request)
        {
            ServiceModel.jSourceResponse result = new ServiceModel.jSourceResponse();
            result.Result = "ERROR";
            try
            {
                SourceObject brow = new SourceObject();
                brow.PK_Source_Id = 0;
                List<SourceObject> bobj = new List<SourceObject>();
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

        public object Any(ServiceModel.SourceSelect_Request request)
        {
            ServiceModel.SourceResponse result = new ServiceModel.SourceResponse();
            ResponseStatus status = new ResponseStatus
            {
                ErrorCode = "Success",
                Message = request.ToString()
            };
            result.Source = dtSource.returnSourceObject();
            return result;
        }

        public object Any(ServiceModel.jSourceSelect_Request request)
        {
            ServiceModel.jSourceResponse result = new ServiceModel.jSourceResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtSource.returnSourceObject();
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

        public object Any(ServiceModel.jSourceUpdate_Request request)
        {
            ServiceModel.jSourceResponse result = new ServiceModel.jSourceResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtSource.updateSourceObject(request);
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

        public object Any(ServiceModel.jSourceCreate_Request request)
        {
            ServiceModel.jSourceRecordResponse result = new ServiceModel.jSourceRecordResponse();
            result.Result = "ERROR";
            try
            {
                result.Record = dtSource.createSourceObject(request);
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

        public object Any(ServiceModel.jSourceDelete_Request request)
        {
            ServiceModel.jSourceResponse result = new ServiceModel.jSourceResponse();
            result.Result = "ERROR";
            try
            {
                dtSource.deleteSourceObject(request);
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
