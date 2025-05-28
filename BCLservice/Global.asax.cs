using System;
using System.Web.ModelBinding;

namespace LSCservice
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //ServiceStack.Licensing.RegisterLicense(@"wvpkPXGeEvOJ16y2Vd/cOFxgjNXghGwzOrVLJ43Ajp5qvWMxZ1mS0MmWgq4MJStsuGstvsWnj4ZaKfZ0tRtEfa4a15STHsZDAa7Qv950b+nMJGzA7vm/dzrnnctl/v5sHZd9MX7iCrHDW03hPC7/zDGj/I3oOtCyVDQelMCOxvI=");
            //LC-4315588-FO12106-250525
            ServiceStack.Licensing.RegisterLicense("OSS GPL-3.0 2025 https://github.com/clifton-collins3iii/LSCInspectionSystem UU5My2D4LKLlramNQfE2FFwTlcX830QPS+0h0BTfLPh+nqHw7uTqVJVCZjv8qy1I09xKyUjsrUPi2J1ruKZmMy3qOP5rGpM18w5w/CYUNZDn0G2MuP85AGL3PSpQlcneCCHFfqnty3YORbU9rIg+b3QreL7xAYINU6tOPBz+vKM=");
            new AppHost().Init();
            
        }
    }
}