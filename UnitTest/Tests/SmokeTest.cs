using NUnit.Framework;
using System;
using System.Threading;
using UnitTest.Data;
using UnitTest.Pages;
using UnitTest.Tools;

namespace UnitTest.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class SmokeTest : TestRunner
    {
        private static readonly IUser[] validUsers = { UserRepository.Get().Registered(), UserRepository.Get().Registered() };
        [Test, TestCaseSource(nameof(validUsers))]
        public void LoginTest(IUser validRegistrator)
        {
            Console.WriteLine("Thread ID = " + Thread.CurrentThread.ManagedThreadId.ToString());
            PageRegistratorHome pageRegistratorHome = StartApplication().SuccessfulLogin(validRegistrator);
            Assert.AreEqual(validRegistrator.Login, pageRegistratorHome.GetLoginNameText());
            PageLogin pageLogin = Logout();
            pageRegistratorHome = StartApplication().SuccessfulLogin(validRegistrator);
            Assert.AreEqual(validRegistrator.Login, pageRegistratorHome.GetLoginNameText());
            isTestSuccess = true;
        }
    }
}
