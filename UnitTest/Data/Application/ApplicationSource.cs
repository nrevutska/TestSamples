using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Data.Application
{
    public class ApplicationSource
    {
        private IList<string> _browserOptions;
        // Browser Data
        public string BrowserName { get; private set; }
        public IList<string> DefaultBrowserOptions
        {
            get
            {
                if(_browserOptions == null)
                {
                    _browserOptions = new List<string>();
                    _browserOptions.Add("--no-proxy-server");
                    _browserOptions.Add("--ignore-certificate-errors");
                }
                return _browserOptions;
            }
        }

        // Implicit and Explicit Waits
        public long ImplicitWaitTimeOut { get; private set; }
        public long ExplicitWaitTimeOut { get; private set; }


        // Localization Strategy

        // Search Strategy

        // Logger Strategy

        // URLs
        public string LoginUrl { get; private set; }
        public string LogoutUrl { get; private set; }
        //
        // Database Connection
        // public string DatabaseUrl { get; private set; }
        // public string DatabaseLogin { get; private set; }
        // public string DatabasePassword { get; private set; }
        //

        public ApplicationSource(string browserName, 
            long implicitWaitTimeOut, 
            long explicitWaitTimeOut, 
            string loginUrl, 
            string logoutUrl)
        {
            BrowserName = browserName;
            ImplicitWaitTimeOut = implicitWaitTimeOut;
            ExplicitWaitTimeOut = explicitWaitTimeOut;
            LoginUrl = loginUrl;
            LogoutUrl = logoutUrl;
        }
    }
}
