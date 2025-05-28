using System;
using System.Collections.Generic;
using ServiceStack;
using LSCservice.ServiceData;


namespace LSCservice.ServiceModel
{
    [Route("/jTable/NopBuilding")]
    public class jTableNOPBuilding_Request : BuildingObjectRow, IReturn<jBuildingResponse>
    {

    }

    [Route("/BuildingSelect")]
    public class BuildingSelect_Request : IReturn<BuildingResponse>
    {
    }

    public class BuildingResponse : IHasResponseStatus
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
        private List<BuildingObject> _Building;
        public List<BuildingObject> Building
        {
            get
            {
                return _Building;
            }
            set
            {
                _Building = value;
            }
        }
        public BuildingResponse()
        {
            this.Building = new List<BuildingObject>();
            this.ResponseStatus = new ResponseStatus();
            this.ResponseStatus.Errors = new List<ResponseError>();
        }
    }

    [Route("/jTable/BuildingSelect")]
    public class jBuildingSelect_Request : IReturn<jBuildingResponse>
    {
    }

    [Route("/jTable/BuildingUpdate")]
    public class jBuildingUpdate_Request : BuildingObjectRow, IReturn<jBuildingResponse>
    {

    }

    [Route("/jTable/BuildingDelete")]
    public class jBuildingDelete_Request : BuildingObjectRow, IReturn<jBuildingResponse>
    {

    }

    [Route("/jTable/BuildingCreate")]
    public class jBuildingCreate_Request : BuildingObjectRow, IReturn<jBuildingRecordResponse>
    {

    }

    public class jBuildingRecordResponse
    {
        public string Result { get; set; }
        public BuildingObjectRow Record { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Record = new BuildingObjectRow();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

    public class jBuildingResponse
    {
        public string Result { get; set; }
        public List<BuildingObject> Records { get; set; }
        public int TotalRecordCount { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Records = new List<BuildingObject>();
            this.Result = string.Empty;
            this.Message = string.Empty;
            this.TotalRecordCount = 0;
        }
    }

}

