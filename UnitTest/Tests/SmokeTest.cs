using NUnit.Framework;
using UnitTest.Data;
using UnitTest.Pages;
using UnitTest.Tools;

namespace UnitTest.Tests
{
    public class SmokeTest : TestRunner
    {
        private static readonly IUser[] validUsers = { UserRepository.Get().Registered() };
        [Test, TestCaseSource(nameof(validUsers))]
        public void LoginTest(IUser validRegistrator)
        {
            PageRegistratorHome pageRegistratorHome = StartApplication().SuccessfulLogin(validRegistrator);
            Assert.AreEqual(validRegistrator.Login, pageRegistratorHome.GetLoginNameText());
            PageLogin pageLogin = Logout();
            pageRegistratorHome = StartApplication().SuccessfulLogin(validRegistrator);
            Assert.AreEqual(validRegistrator.Login, pageRegistratorHome.GetLoginNameText());
            isTestSuccess = true;
        }
    }
}
