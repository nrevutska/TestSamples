using System.Collections.Generic;
using System.Threading;
using UnitTest.Data.Application;
using UnitTest.Pages;

namespace UnitTest.Tools
{
    public class Application
    {
        private volatile static Application instance;
        private Dictionary<int, BrowserWrapper> _browser = new Dictionary<int, BrowserWrapper>();
        private static object lockingObject = new object();

        //TODO Change for parallel work
        public ApplicationSource ApplicationSource { get; private set; }

        // Parallel work in multithreading
        public BrowserWrapper Browser
        {
            get
            {
                int currentThread = Thread.CurrentThread.ManagedThreadId;
                if (!_browser.ContainsKey(currentThread))
                    InitBrowser(currentThread);
                return _browser[currentThread];
            }
        }

        private Application(ApplicationSource applicationSource)
        {
            ApplicationSource = applicationSource;
        }

        private void InitBrowser(int currentThread)
        {
            _browser.Add(currentThread, new BrowserWrapper(this.ApplicationSource));
        }
        private void InitSearch(ApplicationSource applicationSource)
        { }

        public static Application Get()
        {
            return Get(null);
        }

        public static Application Get(ApplicationSource applicationSource)
        {
            if (instance == null)
                lock (lockingObject)
                    if (instance == null)
                    {
                        if (applicationSource == null)
                            applicationSource = ApplicationSourceRepository.Default();
                        instance = new Application(applicationSource);
                    }
            return instance;
        }

        public static void Remove()
        {
            if (instance != null)
            {
                foreach (KeyValuePair<int, BrowserWrapper> kvp in instance._browser)
                    kvp.Value.Quit();
                // Close DB connection etc...
                instance = null;
            }
        }

        public PageLogin LoadPageLogin()
        {
            Browser.OpenUrl(ApplicationSource.LoginUrl);
            Browser.OpenUrl(ApplicationSource.LoginUrl);
            return new PageLogin(Browser.Driver);
        }
        public PageLogin LogoutAction()
        {
            Browser.OpenUrl(ApplicationSource.LogoutUrl);
            return new PageLogin(Browser.Driver);
        }
        public void SaveCurrentState()
        {
            string prefix = Browser.SaveScreenshot();
            Browser.SaveSourceCode(prefix);
        }
    }
}
