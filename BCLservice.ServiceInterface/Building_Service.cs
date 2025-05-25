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
    public class Building_Service : Service
    {
        public object Any(ServiceModel.jTableNOPBuilding_Request request)
        {
            ServiceModel.jBuildingResponse result = new ServiceModel.jBuildingResponse();
            result.Result = "ERROR";
            try
            {
                BuildingObject brow = new BuildingObject();
                brow.PK_Building_Id = 0;
                List<BuildingObject> bobj = new List<BuildingObject>();
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

        public object Any(ServiceModel.BuildingSelect_Request request)
        {
            ServiceModel.BuildingResponse result = new ServiceModel.BuildingResponse();
            ResponseStatus status = new ResponseStatus
            {
                ErrorCode = "Success",
                Message = request.ToString()
            };
            result.Building = dtBuilding.returnBuildingObject();
            return result;
        }

        public object Any(ServiceModel.jBuildingSelect_Request request)
        {
            ServiceModel.jBuildingResponse result = new ServiceModel.jBuildingResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtBuilding.returnBuildingObject();
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

        public object Any(ServiceModel.jBuildingUpdate_Request request)
        {
            ServiceModel.jBuildingResponse result = new ServiceModel.jBuildingResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtBuilding.updateBuildingObject(request);
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

        public object Any(ServiceModel.jBuildingCreate_Request request)
        {
            ServiceModel.jBuildingRecordResponse result = new ServiceModel.jBuildingRecordResponse();
            result.Result = "ERROR";
            try
            {
                result.Record = dtBuilding.createBuildingObject(request);
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

        public object Any(ServiceModel.jBuildingDelete_Request request)
        {
            ServiceModel.jBuildingResponse result = new ServiceModel.jBuildingResponse();
            result.Result = "ERROR";
            try
            {
                dtBuilding.deleteBuildingObject(request);
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
