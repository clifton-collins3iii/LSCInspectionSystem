using ServiceStack;

namespace LSCservice.ServiceModel
{
    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class Hello_Request : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse 
    {
        public string Result { get; set; }
        public ResponseStatus Status { get; set; }
    }
}
