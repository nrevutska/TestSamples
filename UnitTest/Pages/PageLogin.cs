using OpenQA.Selenium;
using System;
using UnitTest.Data;

namespace UnitTest.Pages
{
    public class PageLogin
    {
        private const string LOGIN_ID = "user_login";
        private const string PASSWORD_ID = "user_pass";
        private const string BUTTON_LOGIN_NAME = "wp-submit";

        IWebDriver driver;
        //By _username = By.Id("user_login");
        //By _password = By.XPath("//*[@id=\"user_pass\"]");
        //By _loginButton = By.Name("wp-submit"); 

        //private delegate IWebElement elementGet();


        public IWebElement LoginElement { get { return driver.FindElement(By.Id(LOGIN_ID)); } }
        public IWebElement PasswordElement { get { return driver.FindElement(By.Id(PASSWORD_ID)); } }
        public IWebElement ButtonLogin { get { return driver.FindElement(By.Name(BUTTON_LOGIN_NAME)); } }

        private void SetLoginData(IUser user)
        {

        }

        //private void SetInputDataClear(elementGet inputGet, string data)
        //{
        //    inputGet().Click();
        //    inputGet().Clear();
        //    inputGet().SendKeys(data);
        //}

        private void SetLoginInputClear(string data)
        {
            LoginElement.Click();
            LoginElement.Clear();
            LoginElement.SendKeys(data);
        }

        private void SetPasswordInputClear(string data)
        {
            PasswordElement.Click();
            PasswordElement.Clear();
            PasswordElement.SendKeys(data);
        }


        public PageLogin(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void TypeLoginData(IUser user)
        {
            SetLoginInputClear(user.Login);
            SetPasswordInputClear(user.Password);
            ClickOnLoginButton();
        }

        public void TypePassword(string password)
        {
            //IWebElement passwordElement =(IWebElement)((IJavaScriptExecutor)_driver).ExecuteScript("return document.getElementsByName(\"pwd\")[0];");
            PasswordElement.SendKeys(password);
            //_driver.FindElement(_password).SendKeys(Keys.Enter);
            //_driver.FindElement(_password).SendKeys(Keys.Clear);
        }

        public void ClickOnLoginButton()
        {
            //IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_driver;
            //javaScriptExecutor.ExecuteScript("alert(\"Hello!\")");
            //_driver.SwitchTo().Alert().Accept();

            ButtonLogin.Click();
        }

        public bool VerifyIfLoggedIn()
        {
            driver.FindElement(By.CssSelector("#wp-admin-bar-logout > a"));
            return true;
        }

        public PageRegistratorHome SuccessfulLogin(IUser validUser)
        {
            TypeLoginData(validUser);
            return new PageRegistratorHome(driver);
        }

        public PageRepeatLogin UnSuccessfulLogin(IUser validUser)
        {
            TypeLoginData(validUser);
            return new PageRepeatLogin(driver);
        }

    }
}
