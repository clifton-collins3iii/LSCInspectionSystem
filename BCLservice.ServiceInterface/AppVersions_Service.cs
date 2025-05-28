using System;
using System.Collections.Generic;
using ServiceStack;
using LSCservice.ServiceData;

namespace LSCservice.ServiceInterface
{
    public class AppVersions_Service : Service
    {
        public object Any(ServiceModel.AppVersions_Request request)
        {
            ServiceModel.AppVersionsResponse result = new ServiceModel.AppVersionsResponse();
            ResponseStatus status = new ResponseStatus
            {
                ErrorCode = "Success",
                Message = request.ToString()
            };
            result.AppVersions.Add(dtAppVersions.returnAppVersionObject());
            return result;
        }

    }
}
