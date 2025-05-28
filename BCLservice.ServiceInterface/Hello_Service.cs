using ServiceStack;
using LSCservice.ServiceModel;

namespace LSCservice.ServiceInterface
{
    public class Hello_Service
    {
        public object Any(Hello_Request request)
        {
            ResponseStatus status = new ResponseStatus
            {
                ErrorCode = "Success",
                Message = "Done"
            };
            return new HelloResponse { Result = $"Hello, {request.Name}!", Status = status  };
        }
    }
}
