using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Pages
{
    public class PageRepeatLogin
    {
        private const string DIV_LOGIN_ERROR_ID = "login_error";

        IWebDriver driver;

        public IWebElement LoginErrorDiv { get { return driver.FindElement(By.Id(DIV_LOGIN_ERROR_ID)); } }

        public PageRepeatLogin(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
