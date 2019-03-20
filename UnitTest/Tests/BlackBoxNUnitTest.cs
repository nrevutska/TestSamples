using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using UnitTest.Data;
using UnitTest.Pages;

namespace SetupEnvironmentTest.Tests
{
    [TestFixture]
    //[Parallelizable(ParallelScope.All)]
    class BlackBoxNUnitTest
    {
        static IWebDriver driver;
        static string url;
        static PageLogin pageLogin;

        private static string [][] loginValidParams = {
                                                    new string[] { "admin", "demo123" },
                                                   // new string[] { "admin1", "demo123" }
                                                  };
        private static readonly IUser[] validUsers =
        {
            UserRepository.Get().Registered(),
            UserRepository.Get().Registered(),
            UserRepository.Get().Registered()
        };
        private static readonly IUser[] externalValidUsers = UserRepository.Get().FromCSV().ToArray<IUser>();
       



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
            url = "http://demosite.center/wordpress/wp-login.php";
            driver = new ChromeDriver();
            pageLogin = new PageLogin(driver);
        }

        [SetUp]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl(url);
        }

       // [Test, TestCaseSource(nameof(_loginParams))]
        //[Test, TestCase("admin", "demo123"/*, ExpectedResult = true*/)]
        public void TestMethodLogin(string login /*[Values("admin", "admin1")]*/, string password/*[Values("demo123", "demo123")]*/)
        {
            driver.Navigate().GoToUrl(url);

            pageLogin.SuccessfulLogin(new User(login, password));
            Assert.IsTrue(pageLogin.VerifyIfLoggedIn());

        }
        [Test, TestCaseSource(nameof(externalValidUsers))]
        public void LoginTest(IUser validRegistrator)
        {
            PageRegistratorHome pageRegistratorHome = new PageLogin(driver).SuccessfulLogin(validRegistrator);
            Assert.AreEqual(validRegistrator.Login, pageRegistratorHome.GetLoginNameText());
        }

        //[Test]
        public void LoginUnsuccessTest()
        {
            PageRepeatLogin pageRepeatLogin = new PageLogin(driver).UnSuccessfulLogin(UserRepository.Get().Invalid());
            Assert.IsTrue(pageRepeatLogin.LoginErrorDiv.Displayed);
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            driver.Quit();
        }
    }
}
