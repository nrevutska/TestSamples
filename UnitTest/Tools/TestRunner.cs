using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Pages;

namespace UnitTest.Tools
{
    public abstract class TestRunner
    {
        protected bool isTestSuccess;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            Application.Get();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Application.Remove();
        }

        [SetUp]
        public void SetUp()
        {
            isTestSuccess = false;
        }
        [TearDown]
        public void TearDown()
        {
            //if (!isTestSuccess)
            //    Application.Get().SaveCurrentState();

            if(TestContext.CurrentContext.Result.Outcome.Equals(TestStatus.Failed))
                Application.Get().SaveCurrentState();
             Application.Get().LogoutAction();
       }

        protected PageLogin StartApplication()
        {
            return Application.Get().LoadPageLogin();
        }
        protected PageLogin Logout()
        {
            return Application.Get().LogoutAction();
        }
    }
}
