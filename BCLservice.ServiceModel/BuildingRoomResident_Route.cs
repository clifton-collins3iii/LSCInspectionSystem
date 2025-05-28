using System;
using System.Collections.Generic;
using ServiceStack;
using LSCservice.ServiceData;

namespace LSCservice.ServiceModel
{
    [Route("/jTable/NopBuildingRoomResident")]
    public class jTableNOPBuildingRoomResident_Request : BuildingRoomResidentObjectRow, IReturn<jBuildingRoomResidentResponse>
    {

    }

    [Route("/BuildingRoomResidentSelect")]
    public class BuildingRoomResidentSelect_Request : BuildingRoomResidentObjectRow, IReturn<jBuildingRoomResidentResponse>
    {
    }

    public class BuildingRoomResidentResponse : IHasResponseStatus
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
        private List<BuildingRoomResidentObject> _Room;
        public List<BuildingRoomResidentObject> BuildingRoomResident
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
        public BuildingRoomResidentResponse()
        {
            this.BuildingRoomResident = new List<BuildingRoomResidentObject>();
            this.ResponseStatus = new ResponseStatus();
            this.ResponseStatus.Errors = new List<ResponseError>();
        }
    }

    [Route("/jTable/BuildingRoomResidentSelect")]
    public class jBuildingRoomResidentSelect_Request : IReturn<jBuildingRoomResidentResponse>
    {
        public int FK_Building_Id { get; set; }
    }

    [Route("/jTable/BuildingRoomResidentUpdate")]
    public class jBuildingRoomResidentUpdate_Request : BuildingRoomResidentObjectRow, IReturn<jBuildingRoomResidentResponse>
    {

    }

    [Route("/jTable/BuildingRoomResidentDelete")]
    public class jBuildingRoomResidentDelete_Request : BuildingRoomResidentObjectRow, IReturn<jBuildingRoomResidentResponse>
    {

    }

    [Route("/jTable/BuildingRoomResidentCreate")]
    public class jBuildingRoomResidentCreate_Request : BuildingRoomResidentObjectRow, IReturn<jBuildingRoomResidentRecordResponse>
    {

    }

    public class jBuildingRoomResidentRecordResponse
    {
        public string Result { get; set; }
        public BuildingRoomResidentObjectRow Record { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Record = new BuildingRoomResidentObjectRow();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

    public class jBuildingRoomResidentResponse
    {
        public string Result { get; set; }
        public List<BuildingRoomResidentObject> Records { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Records = new List<BuildingRoomResidentObject>();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

}

