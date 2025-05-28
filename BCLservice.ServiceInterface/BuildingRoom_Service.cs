using LSCservice.ServiceData;
using ServiceStack;
using System;
using System.Collections.Generic;
using LSCservice.ServiceData.BCLservice.ServiceData;

namespace LSCservice.ServiceInterface
{
    public class BuildingRoom_Service : Service
    {
        public object Any(ServiceModel.jTableNOPBuildingRoom_Request request)
        {
            ServiceModel.jBuildingRoomResponse result = new ServiceModel.jBuildingRoomResponse();
            result.Result = "ERROR";
            try
            {
                BuildingRoomObject brow = new BuildingRoomObject();
                brow.PK_BuildingRoom_Id = 0;
                List<BuildingRoomObject> bobj = new List<BuildingRoomObject>();
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

        public object Any(ServiceModel.BuildingRoomSelect_Request request)
        {
            ServiceModel.BuildingRoomResponse result = new ServiceModel.BuildingRoomResponse();
            ResponseStatus status = new ResponseStatus
            {
                ErrorCode = "Success",
                Message = request.ToString()
            };
            result.BuildingRoom = dtBuildingRoom.returnBuildingRoomObject();
            return result;
        }
        public object Any(ServiceModel.jBuildingRoomSelect_Request request)
        {
            ServiceModel.jBuildingRoomResponse result = new ServiceModel.jBuildingRoomResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtBuildingRoom.returnBuildingRoomObject();
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

        public object Any(ServiceModel.jBuildingRoomUpdate_Request request)
        {
            ServiceModel.jBuildingRoomResponse result = new ServiceModel.jBuildingRoomResponse();
            result.Result = "ERROR";
            try
            {
                result.Records = dtBuildingRoom.updateBuildingRoomObject(request);
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

        public object Any(ServiceModel.jBuildingRoomCreate_Request request)
        {
            ServiceModel.jBuildingRoomRecordResponse result = new ServiceModel.jBuildingRoomRecordResponse();
            result.Result = "ERROR";
            try
            {
                result.Record = dtBuildingRoom.createBuildingRoomObject(request);
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

        public object Any(ServiceModel.jBuildingRoomDelete_Request request)
        {
            ServiceModel.jBuildingRoomResponse result = new ServiceModel.jBuildingRoomResponse();
            result.Result = "ERROR";
            try
            {
                dtBuildingRoom.deleteBuildingRoomObject(request);
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
