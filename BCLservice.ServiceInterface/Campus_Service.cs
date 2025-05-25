using BCLservice.ServiceData;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCLservice.ServiceData.BCLservice.ServiceData;

namespace BCLservice.ServiceInterface
{
    public class Campus_Service : Service
    {
        public object Any(ServiceModel.jTableNOPCampus_Request request)
        {
            ServiceModel.jCampusResponse result = new ServiceModel.jCampusResponse();
            result.Result = "ERROR";
            try
            {
                CampusObject brow = new CampusObject();
                brow.PK_Campus_Id = 0;
                List<CampusObject> bobj = new List<CampusObject>();
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

        public object Any(ServiceModel.CampusSelect_Request request)
        {
            ServiceModel.CampusResponse result = new ServiceModel.CampusResponse();
            ResponseStatus status = new ResponseStatus
            {
                ErrorCode = "Success",
                Message = request.ToString()
            };
            result.Campus = dtCampus.returnCampusObject();
            return result;
        }

        public object Any(ServiceModel.jCampusSelect_Request request)
        {
            ServiceModel.jCampusResponse result = new ServiceModel.jCampusResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtCampus.returnCampusObject();
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

        public object Any(ServiceModel.jCampusUpdate_Request request)
        {
            ServiceModel.jCampusResponse result = new ServiceModel.jCampusResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtCampus.updateCampusObject(request);
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

        public object Any(ServiceModel.jCampusCreate_Request request)
        {
            ServiceModel.jCampusRecordResponse result = new ServiceModel.jCampusRecordResponse();
            result.Result = "ERROR";
            try
            {
                result.Record = dtCampus.createCampusObject(request);
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

        public object Any(ServiceModel.jCampusDelete_Request request)
        {
            ServiceModel.jCampusResponse result = new ServiceModel.jCampusResponse();
            result.Result = "ERROR";
            try
            {
                dtCampus.deleteCampusObject(request);
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
