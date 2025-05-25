using System;
using System.Web.ModelBinding;

namespace BCLservice
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //ServiceStack.Licensing.RegisterLicense(@"wvpkPXGeEvOJ16y2Vd/cOFxgjNXghGwzOrVLJ43Ajp5qvWMxZ1mS0MmWgq4MJStsuGstvsWnj4ZaKfZ0tRtEfa4a15STHsZDAa7Qv950b+nMJGzA7vm/dzrnnctl/v5sHZd9MX7iCrHDW03hPC7/zDGj/I3oOtCyVDQelMCOxvI=");
            ServiceStack.Licensing.RegisterLicense("OSS GPL-2.0 2024 https://github.com/clifton-collins3iii/BreakingChainsSystem Exw1VzbgsRg7KAx9CBGaBYwuhfDbPheOdyVrV3gL20En3AGnhTxUBBwJJrEyYHaBHmdZbdjBTuqhQb/LGoz3btKSest475XxeCsTUj/vy1C5phI9BYd6BWgUbsIBCOpsU/DHCD1dJsKlBo8TnlLJ9zIwME07UNv//tXGnxUixiw=");
            new AppHost().Init();
            
        }
    }
}