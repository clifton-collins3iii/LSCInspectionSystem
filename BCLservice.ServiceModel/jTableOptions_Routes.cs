using BCLservice.ServiceData;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCLservice.ServiceData.BCLservice;
namespace BCLservice.ServiceModel
{
    internal class jTableOptions_Routes
    {
    }

    [Route("/jTableOptions/BuildingOptionsSelect")]
    public class jBuildingOptions_Request : IReturn<jTableOptionsResponse>
    {
    }

    [Route("/jTableOptions/StateOptionsSelect")]
    public class jStatesOptions_Request : IReturn<jTableOptionsResponse>
    {
    }

    [Route("/jTableOptions/RentPaymentFrequencyOptionsSelect")]
    public class jRentPaymentFrequencyOptions_Request : IReturn<jTableOptionsResponse>
    {
    }

    [Route("/jTableOptions/ResidentOptionsSelect")]
    public class jResidentOptions_Request : IReturn<jTableOptionsResponse>
    {
    }

    [Route("/jTableOptions/RoomOptionsSelect")]
    public class jRoomOptions_Request : IReturn<jTableOptionsResponse>
    {
        public string PK_Building_Id { get; set; }
    }

    [Route("/jTableOptions/ContactOptionsSelect")]
    public class jContactOptions_Request : IReturn<jTableOptionsResponse>
    {
        public string PK_Source_Id { get; set; }
    }

    public class jTableOptionsResponse
    {
        public string Result { get; set; }
        public List<jTableOptionsObject> Options { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Options = new List<jTableOptionsObject>();
            this.Result = string.Empty;
            this.Message = string.Empty;
        }
    }

    public class jTableStrOptionsResponse
    {
        public string Result { get; set; }
        public List<jTableStrOptionsObject> Options { get; set; }
        public string Message { get; set; }

        public void New()
        {
            this.Options = new List<jTableStrOptionsObject>();
            this.Result = string.Empty;
            this.Message = string.Empty;
        }
    }
}