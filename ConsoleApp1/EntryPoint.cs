using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

public class EntryPoint
{
    static void Main()
    {
        // RADIO BUTTONS
        //string url = "http://testing.todvachev.com/special-elements/radio-button-test/";
        //string[] number = { "1", "3", "5" };
        //IWebDriver driver = new ChromeDriver();
        //driver.Navigate().GoToUrl(url);
        //try
        //{
        //    for (int i = 0; i < number.Length; i++)
        //    {
        //        string cssPath = string.Format(" #post-10 > div > form > p:nth-child(6) > input[type=\"radio\"]:nth-child({0}", number[i]);
        //        IWebElement element = driver.FindElement(By.CssSelector(cssPath));
        //       // element.Click();
        //        if (element.GetAttribute("checked") != null)
        //            Console.WriteLine(String.Format("Element {0} is checked", element.GetAttribute("value")));
        //        else
        //            Console.WriteLine(String.Format("Element {0} is NOT checked", element.GetAttribute("value")));
        //    }

        //}
        //catch (NoSuchElementException)
        //{
        //    Console.WriteLine("Element was not found");
        //}



        //DROP DOWN LIST
        //string url = "http://testing.todvachev.com/special-elements/drop-down-menu-test/";
        //string[] number = { "1", "2", "3", "4" };
        //IWebDriver driver = new ChromeDriver();
        //driver.Navigate().GoToUrl(url);
        //try
        //{
        //    string name = "DropDownTest";
        //    IWebElement dropDownElement = driver.FindElement(By.Name(name));
        //    Console.WriteLine("Selected value is " + dropDownElement.GetAttribute("Value"));
        //    Console.WriteLine(dropDownElement.GetAttribute("Value"));

        //    for (int i = 0; i < number.Length; i++)
        //    {
        //        string cssPath = string.Format("#post-6 > div > p:nth-child(6) > select > option:nth-child({0})", number[i]);
        //        IWebElement element = driver.FindElement(By.CssSelector(cssPath));
        //        element.Click();
        //        string value = element.GetAttribute("Value");
        //        Thread.Sleep(3000);
        //        Console.WriteLine(value);
        //    }

        //}
        //catch (NoSuchElementException)
        //{
        //    Console.WriteLine("Element was not found");
        //}


        string url = "http://testing.todvachev.com/special-elements/alert-box/";
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(url);
        IAlert alert = driver.SwitchTo().Alert();
        Console.WriteLine(alert.Text);
        Thread.Sleep(3000);
        alert.Accept();
        try
        {
            IWebElement imgAfterAlert = driver.FindElement(By.CssSelector("#post-119 > div > figure > img"));
            Console.WriteLine("The alert was successfully accepted and I see the image!");
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Element was not found");
        }

        Thread.Sleep(3000);
        driver.Quit();
        Console.ReadLine();
    }

    public int FormulaEvaluate(int a, int b, int c)
    {
        if (a == -1)
            return 0;
        return a + b * c;
    }
}
