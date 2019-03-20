using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Data.Application;
using UnitTest.Pages;

namespace UnitTest.Tools
{
    public interface IBrowser
    {
        // Factory Method
        IWebDriver GetBrowser(ApplicationSource applicationSource);
    }

    public class ChromeTemporary : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            return new ChromeDriver();
        }
    }
    public class ChromeTemporaryWithoutUI : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-proxy-server", "--ignore-certificate-errors", "--headless");
            //options.AddArguments(Application.Get().ApplicationSource.DefaultBrowserOptions);
            //options.AddArguments("--headless");
            return new ChromeDriver(options);
        }
    }
    public class ChromeTemporaryMaximized : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-proxy-server", "--ignore-certificate-errors", "--start-maximized");
            return new ChromeDriver(options);
        }
    }
    public class BrowserWrapper
    {
        private const string STRING_TRUE = "true";
        private const string TIME_TEMPLATE = "yyyy_MM_dd_HH_mm_ss";
        private const string SCREENSHOT_PNG = "_Screenshot.png";
        private const string SOURCECODE_TXT = "_SourceCode.txt";
        private const string IS_CONTINUOUS_INTEGRATION = "IS_CONTINUOUS_INTEGRATION";
        private const string DEFAULT_BROWSER = ApplicationSourceRepository.CROME_TEMPORARY;
        private const string CONTINUOUS_INTEGRATION_BROWSER = ApplicationSourceRepository.CROME_TEMPORARY_WITHOUT_UI;

        private Dictionary<string, IBrowser> Browsers;

        public IWebDriver Driver { get; private set; }

        public BrowserWrapper(ApplicationSource applicationSource)
        {
            InitDictionary();
            InitWebDriver(applicationSource);
        }

        private void InitDictionary()
        {
            Browsers = new Dictionary<string, IBrowser>();
            Browsers.Add(DEFAULT_BROWSER, new ChromeTemporary());
            Browsers.Add(ApplicationSourceRepository.CROME_TEMPORARY_MAXIMIZED, new ChromeTemporaryMaximized());
            Browsers.Add(ApplicationSourceRepository.CROME_TEMPORARY_WITHOUT_UI, new ChromeTemporaryWithoutUI());
        }

        private void InitWebDriver(ApplicationSource applicationSource)
        {
            IBrowser currentBrowser;
            if (IsContinuousIntegration())
                currentBrowser = Browsers[CONTINUOUS_INTEGRATION_BROWSER];
            else
            {
                currentBrowser = Browsers[DEFAULT_BROWSER];
                foreach (string key in Browsers.Keys)
                    if (key.ToLower().Equals(applicationSource.BrowserName.ToLower()))
                    {
                        currentBrowser = Browsers[key];
                        break;
                    }
                Driver = currentBrowser.GetBrowser(applicationSource);
            }
        }

        private bool IsContinuousIntegration()
        {
            return Environment.GetEnvironmentVariable(IS_CONTINUOUS_INTEGRATION) == STRING_TRUE;
        }

        private string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase).Substring(AExternalReader.PATH_PREFIX);
        }

        public string SaveScreenshot()
        {
            return SaveScreenshot(null);
        }
        public string SaveScreenshot(string namePrefix)
        {
            if (namePrefix == null || namePrefix.Length == 0)
                namePrefix = GetTime();
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)Driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(GetCurrentDirectory() + AExternalReader.PATH_SEPARATOR + namePrefix + SCREENSHOT_PNG, ScreenshotImageFormat.Png);
            return namePrefix;
        }
        public string SaveSourceCode()
        {
            return SaveSourceCode(null);
        }
        public string SaveSourceCode(string namePrefix)
        {
            if (namePrefix == null || namePrefix.Length == 0)
                namePrefix = GetTime();            
            File.WriteAllText(GetCurrentDirectory() + AExternalReader.PATH_SEPARATOR + namePrefix + SOURCECODE_TXT, Driver.PageSource);
            return namePrefix;
        }

        private string GetTime()
        {
            DateTime localDate = DateTime.Now;
            return localDate.ToString(TIME_TEMPLATE);
        }

        public void OpenUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
        public void NavigateForward(string url)
        {
            Driver.Navigate().Forward();
        }
        public void NavigateBack(string url)
        {
            Driver.Navigate().Back();
        }
        public void RefreshPage(string url)
        {
            Driver.Navigate().Refresh();
        }
        public void Quit()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}
