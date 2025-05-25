using BCLservice.ServiceData;
using ServiceStack;
using System;
using System.Collections.Generic;
using BCLservice.ServiceData.BCLservice.ServiceData;

namespace BCLservice.ServiceInterface
{
    public class jTableOptions_Services : Service
    {

        public object Any(ServiceModel.jBuildingOptions_Request request)
        {
            ServiceModel.jTableOptionsResponse result = new ServiceModel.jTableOptionsResponse();
            result.Result = "ERROR";
            try
            {
                result.Options = dtTableOptions_Services.returnBuildingOptionsObject();
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

        public object Any(ServiceModel.jStatesOptions_Request request)
        {
            ServiceModel.jTableStrOptionsResponse result = new ServiceModel.jTableStrOptionsResponse();
            result.Result = "ERROR";
            try
            {
                result.Options = dtTableOptions_Services.returnStatesOptionsObject();
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

        public object Any(ServiceModel.jRentPaymentFrequencyOptions_Request request)
        {
            ServiceModel.jTableStrOptionsResponse result = new ServiceModel.jTableStrOptionsResponse();
            result.Result = "ERROR";
            try
            {
                result.Options = dtTableOptions_Services.returnRentPaymentFrequencyOptionsObject();
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

        public object Any(ServiceModel.jResidentOptions_Request request)
        {
            ServiceModel.jTableOptionsResponse result = new ServiceModel.jTableOptionsResponse();
            result.Result = "ERROR";
            try
            {
                result.Options = dtTableOptions_Services.returnResidentOptionsObject();
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

        public object Any(ServiceModel.jRoomOptions_Request request)
        {
            ServiceModel.jTableOptionsResponse result = new ServiceModel.jTableOptionsResponse();
            result.Result = "ERROR";
            try
            {
                result.Options = dtTableOptions_Services.returnRoomOptionsObject(request.PK_Building_Id);
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

        public object Any(ServiceModel.jContactOptions_Request request)
        {
            ServiceModel.jTableOptionsResponse result = new ServiceModel.jTableOptionsResponse();
            result.Result = "ERROR";
            try
            {
                result.Options = dtTableOptions_Services.returnContactOptionsObject(request.PK_Source_Id);
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
