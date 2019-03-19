using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Pages
{
    public class PageRegistratorHome
    {
        private const string SPAN_LOGIN_NAME_CSS = "#wp-admin-bar-my-account > a > span";

        IWebDriver driver;

        public IWebElement LoginNameSpan { get { return driver.FindElement(By.CssSelector(SPAN_LOGIN_NAME_CSS)); } }

        public PageRegistratorHome(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetLoginNameText()
        {
            return LoginNameSpan.Text;
        }
    }
}
