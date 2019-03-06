using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTest.Pages;

namespace SetupEnvironmentTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    //[TestClass]
    public class BlackBoxWithDriverTest
    {
        public BlackBoxWithDriverTest()
        {
        }

        private TestContext testContextInstance;
        private static IWebDriver _driver;
        private static string _url;
        private static PageLogin _pageLogin;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _url = "http://testing.todvachev.com/special-elements/text-input-field/";
            _driver = new ChromeDriver();
            _pageLogin = new PageLogin(_driver);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        [TestMethod]
        public void TestMethodLogin()
        {
            //PageLogin.Type
            //Assert.Inconclusive();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _driver.Quit();
        }
    }
}
