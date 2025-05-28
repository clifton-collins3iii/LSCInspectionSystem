using LSCservice.ServiceData;
using ServiceStack;
using System;
using System.Collections.Generic;
using LSCservice.ServiceData.BCLservice.ServiceData;

namespace LSCservice.ServiceInterface
{
    public class BuildingRoomResident_Service : Service
    {
        public object Any(ServiceModel.jTableNOPBuildingRoomResident_Request request)
        {
            ServiceModel.jBuildingRoomResidentResponse result = new ServiceModel.jBuildingRoomResidentResponse();
            result.Result = "ERROR";
            try
            {
                BuildingRoomResidentObject brow = new BuildingRoomResidentObject();
                brow.PK_RoomResident_Id = 0;
                List<BuildingRoomResidentObject> bobj = new List<BuildingRoomResidentObject>();
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

        public object Any(ServiceModel.BuildingRoomResidentSelect_Request request)
        {
            ServiceModel.BuildingRoomResidentResponse result = new ServiceModel.BuildingRoomResidentResponse();
            ResponseStatus status = new ResponseStatus
            {
                ErrorCode = "Success",
                Message = request.ToString()
            };
            result.BuildingRoomResident = dtBuildingRoomResident.returnBuildingRoomResidentObject(request.FK_BuildingRoom_Id);
            return result;
        }

        public object Any(ServiceModel.jBuildingRoomResidentSelect_Request request)
        {
            ServiceModel.jBuildingRoomResidentResponse result = new ServiceModel.jBuildingRoomResidentResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtBuildingRoomResident.returnBuildingRoomResidentObject(request.FK_Building_Id);
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

        public object Any(ServiceModel.jBuildingRoomResidentUpdate_Request request)
        {
            ServiceModel.jBuildingRoomResidentResponse result = new ServiceModel.jBuildingRoomResidentResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtBuildingRoomResident.updateBuildingRoomResidentObject(request);
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

        public object Any(ServiceModel.jBuildingRoomResidentCreate_Request request)
        {
            ServiceModel.jBuildingRoomResidentRecordResponse result = new ServiceModel.jBuildingRoomResidentRecordResponse();
            result.Result = "ERROR";
            try
            {
                result.Record = dtBuildingRoomResident.createBuildingRoomResidentObject(request);
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

        public object Any(ServiceModel.jBuildingRoomResidentDelete_Request request)
        {
            ServiceModel.jBuildingRoomResidentResponse result = new ServiceModel.jBuildingRoomResidentResponse();
            result.Result = "ERROR";
            try
            {
                dtBuildingRoomResident.deleteBuildingRoomResidentObject(request);
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
