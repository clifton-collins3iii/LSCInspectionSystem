using Funq;
using ServiceStack;
using ServiceStack.ServiceInterface;
using LSCservice.ServiceInterface;

namespace LSCservice
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyAspNet
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("LSCservice", typeof(Building_Service).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            this.Plugins.Add(new CorsFeature());
        }
    }
}