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
    public class MySurvey_Service : Service
    {
        public object Any(ServiceModel.jTableNOPMySurvey_Request request)
        {
            ServiceModel.jMySurveyResponse result = new ServiceModel.jMySurveyResponse();
            result.Result = "ERROR";
            try
            {
                MySurveyObject brow = new MySurveyObject();
                brow.PK_InspectionSurvey_Id = 0;
                List<MySurveyObject> bobj = new List<MySurveyObject>();
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

        public object Any(ServiceModel.MySurveySelect_Request request)
        {
            ServiceModel.MySurveyResponse result = new ServiceModel.MySurveyResponse();
            ResponseStatus status = new ResponseStatus
            {
                ErrorCode = "Success",
                Message = request.ToString()
            };
            result.MySurvey = dtMySurvey.returnMySurveyObject();
            return result;
        }

        public object Any(ServiceModel.jMySurveySelect_Request request)
        {
            ServiceModel.jMySurveyResponse result = new ServiceModel.jMySurveyResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtMySurvey.returnMySurveyObject();
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

        public object Any(ServiceModel.jMySurveyUpdate_Request request)
        {
            ServiceModel.jMySurveyResponse result = new ServiceModel.jMySurveyResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtMySurvey.updateMySurveyObject(request);
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

        public object Any(ServiceModel.jMySurveyCreate_Request request)
        {
            ServiceModel.jMySurveyRecordResponse result = new ServiceModel.jMySurveyRecordResponse();
            result.Result = "ERROR";
            try
            {
                result.Record = dtMySurvey.createMySurveyObject(request);
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

        public object Any(ServiceModel.jMySurveyDelete_Request request)
        {
            ServiceModel.jMySurveyResponse result = new ServiceModel.jMySurveyResponse();
            result.Result = "ERROR";
            try
            {
                dtMySurvey.deleteMySurveyObject(request);
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
