using System;
using System.Collections.Generic;
using ServiceStack;
using LSCservice.ServiceData;

namespace LSCservice.ServiceModel
{
    [Route("/jTable/NopBuildingRoom")]
    public class jTableNOPBuildingRoom_Request : BuildingRoomObjectRow, IReturn<jBuildingRoomResponse>
    {

    }

    [Route("/RoomSelect")]
    public class BuildingRoomSelect_Request : IReturn<jBuildingRoomResponse>
    {
    }

    public class BuildingRoomResponse : IHasResponseStatus
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
        private List<BuildingRoomObject> _Room;
        public List<BuildingRoomObject> BuildingRoom
        {
            get
            {
                return _Room;
            }
            set
            {
                _Room = value;
            }
        }
        public BuildingRoomResponse()
        {
            this.BuildingRoom = new List<BuildingRoomObject>();
            this.ResponseStatus = new ResponseStatus();
            this.ResponseStatus.Errors = new List<ResponseError>();
        }
    }

    [Route("/jTable/RoomSelect")]
    public class jBuildingRoomSelect_Request : IReturn<jBuildingRoomResponse>
    {
    }

    [Route("/jTable/RoomUpdate")]
    public class jBuildingRoomUpdate_Request : BuildingRoomObjectRow, IReturn<jBuildingRoomResponse>
    {

    }

    [Route("/jTable/RoomDelete")]
    public class jBuildingRoomDelete_Request : BuildingRoomObjectRow, IReturn<jBuildingRoomResponse>
    {

    }

    [Route("/jTable/RoomCreate")]
    public class jBuildingRoomCreate_Request : BuildingRoomObjectRow, IReturn<jBuildingRoomRecordResponse>
    {

    }

    public class jBuildingRoomRecordResponse
    {
        public string Result { get; set; }
        public BuildingRoomObjectRow Record { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Record = new BuildingRoomObjectRow();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

    public class jBuildingRoomResponse
    {
        public string Result { get; set; }
        public List<BuildingRoomObject> Records { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Records = new List<BuildingRoomObject>();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

}

