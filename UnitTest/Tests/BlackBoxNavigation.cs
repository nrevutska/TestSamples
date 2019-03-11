using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SetupEnvironmentTest.Tests
{
    [TestFixture]
    class BlackBoxNavigation
    {
        static IWebDriver _driver;
        static string _url = "http://testing.todvachev.com/special-elements/radio-button-test/";

        [OneTimeSetUp]
        public void ClassSetUp()
        {
            _driver = new ChromeDriver();
        }

        [SetUp]
        public void TestSetUp()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        [Test]
        public void TestMethod()
        {
            IWebElement position = _driver.FindElement(By.Id("comment"));
            Actions action = new Actions(_driver);
            action.MoveToElement(position).Perform();
            // action.ClickAndHold().MoveToElement(position).Perform();

            //IJavaScriptExecutor javaScript = (IJavaScriptExecutor)_driver;
            // javaScript.ExecuteScript("arguments[0].scrollIntoView(true);", position);
            Thread.Sleep(3000);
        }

        [OneTimeTearDown]
        public void ClassTearDown()
        {
            _driver.Quit();
        }
    }
}
