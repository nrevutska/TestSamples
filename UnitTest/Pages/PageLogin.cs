using OpenQA.Selenium;
using System;

namespace UnitTest.Pages
{
    public class PageLogin
    {
        IWebDriver _driver;
        By _username = By.Id("user_login");
        By _password = By.XPath("//*[@id=\"user_pass\"]");
        By _loginButton = By.Name("wp-submit"); 


        public PageLogin(IWebDriver driver)
        {
            _driver = driver;
        }

        public void TypeLoginName(string loginName)
        {
            _driver.FindElement(_username).SendKeys(loginName);
        }

        public void TypePassword(string password)
        {
            _driver.FindElement(_password).SendKeys(password);
        }

        public void ClickOnLoginButton()
        {
            _driver.FindElement(_loginButton).Click();
        }
 
    
    }
}
