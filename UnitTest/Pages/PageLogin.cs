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
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void TypeLoginName(string loginName)
        {
            IWebElement userName = _driver.FindElement(_username);
            userName.Clear();
            userName.SendKeys(loginName);
        }

        public void TypePassword(string password)
        {
            IWebElement passwordElement = _driver.FindElement(_password);

            //IWebElement passwordElement =(IWebElement)((IJavaScriptExecutor)_driver).ExecuteScript("return document.getElementsByName(\"pwd\")[0];");
            passwordElement.Clear();
            passwordElement.SendKeys(password);
            //_driver.FindElement(_password).SendKeys(Keys.Enter);
            //_driver.FindElement(_password).SendKeys(Keys.Clear);
        }

        public void ClickOnLoginButton()
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_driver;
            javaScriptExecutor.ExecuteScript("alert(\"Hello!\")");
            _driver.SwitchTo().Alert().Accept();

            _driver.FindElement(_loginButton).Click();
        }

        public bool VerifyIfLoggedIn()
        {
            _driver.FindElement(By.CssSelector("#wp-admin-bar-logout > a"));
            return true;
        }
 
    
    }
}
