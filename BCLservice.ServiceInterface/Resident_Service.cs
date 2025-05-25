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
    public class Resident_Service : Service
    {
        public object Any(ServiceModel.jTableNOPResident_Request request)
        {
            ServiceModel.jResidentResponse result = new ServiceModel.jResidentResponse();
            result.Result = "ERROR";
            try
            {
                ResidentObject brow = new ResidentObject();
                brow.PK_Resident_Id = 0;
                List<ResidentObject> bobj = new List<ResidentObject>();
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

        public object Any(ServiceModel.ResidentSelect_Request request)
        {
            ServiceModel.ResidentResponse result = new ServiceModel.ResidentResponse();
            ResponseStatus status = new ResponseStatus
            {
                ErrorCode = "Success",
                Message = request.ToString()
            };
            result.Resident = dtResident.returnResidentObject();
            return result;
        }

        public object Any(ServiceModel.jResidentSelect_Request request)
        {
            ServiceModel.jResidentResponse result = new ServiceModel.jResidentResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtResident.returnResidentObject();
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

        public object Any(ServiceModel.jResidentUpdate_Request request)
        {
            ServiceModel.jResidentResponse result = new ServiceModel.jResidentResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtResident.updateResidentObject(request);
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

        public object Any(ServiceModel.jResidentCreate_Request request)
        {
            ServiceModel.jResidentRecordResponse result = new ServiceModel.jResidentRecordResponse();
            result.Result = "ERROR";
            try
            {
                result.Record = dtResident.createResidentObject(request);
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

        public object Any(ServiceModel.jResidentDelete_Request request)
        {
            ServiceModel.jResidentResponse result = new ServiceModel.jResidentResponse();
            result.Result = "ERROR";
            try
            {
                dtResident.deleteResidentObject(request);
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
