using System;
using System.Collections.Generic;
using ServiceStack;
using LSCservice.ServiceData;

namespace LSCservice.ServiceModel
{
    [Route ("/AppVersions")]
    public class AppVersions_Request : AppVersionObject, IReturn<AppVersionsResponse>
    {
        private List<AppVersionObject> _AppVersions;
        public List<AppVersionObject> AppVersions
        {
            get
            {
                return _AppVersions;
            }
            set
            {
                _AppVersions = value;
            }
        }
    }

    public class AppVersionsResponse : IHasResponseStatus
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
        private List<AppVersionObject> _AppVersions;
        public List<AppVersionObject> AppVersions
        {
            get
            {
                return _AppVersions;
            }
            set
            {
                _AppVersions = value;
            }
        }
        public AppVersionsResponse()
        {
            this.AppVersions = new List<AppVersionObject>();
            this.ResponseStatus = new ResponseStatus();
            this.ResponseStatus.Errors = new List<ResponseError>();
        }
    }

}
