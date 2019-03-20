using UnitTest.Data.Application;
using UnitTest.Pages;

namespace UnitTest.Tools
{
    public class Application
    {
        private volatile static Application instance;
        private static object lockingObject = new object();

        public ApplicationSource ApplicationSource { get; private set; }
        public BrowserWrapper Browser { get; private set; }

        private Application(ApplicationSource applicationSource)
        {
            ApplicationSource = applicationSource;
        }

        private void InitBrowser(ApplicationSource applicationSource)
        {
            Browser = new BrowserWrapper(applicationSource);
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
                        instance.InitBrowser(applicationSource);
                        instance.InitSearch(applicationSource);
                    }
            return instance;
        }

        public static void Remove()
        {
            if (instance != null)
            {
                Get().Browser.Quit();
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
