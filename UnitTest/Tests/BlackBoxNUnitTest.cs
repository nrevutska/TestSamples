using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTest.Pages;

namespace SetupEnvironmentTest.Tests
{
    [TestFixture]
    class BlackBoxNUnitTest
    {
        static IWebDriver _driver;
        static string _url;
        static PageLogin _pageLogin;
    
         

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use OneTimeSetUp to run code before running the first test in the class
        //
        // Use OneTimeTearDown to run code after all tests in a class have run
        //
        // Use Setup to run code before running each test 
        //
        // Use TearDown to run code after each test has run
        //
        #endregion

        [OneTimeSetUp]
        public void ClassInitialize()
        {
            _url = "http://demosite.center/wordpress/wp-login.php";
            _driver = new ChromeDriver();
            _pageLogin = new PageLogin(_driver);
        }

        [SetUp]
        public void TestInitialize()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        [Test]
        [TestCase("admin", "demo123", ExpectedResult = true)]
        public bool TestMethodLogin(string login, string password)
        {
            _driver.Navigate().GoToUrl(_url);
            _pageLogin.TypeLoginName(login);
            _pageLogin.TypePassword(password);
            _pageLogin.ClickOnLoginButton();
            return true;
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            _driver.Quit();
        }
    }
}
