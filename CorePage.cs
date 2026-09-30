using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace DemoQA_Automation
{
    public class CorePage
    {
        public static IWebDriver driver;

        public IWebDriver SeleniumInit()
        {
            bool isHeadless = bool.Parse(ConfigurationManager.AppSettings["Headless"] ?? "false");
            ChromeOptions options = new ChromeOptions();
            if (isHeadless)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--window-size=1920,1080");
            }
            IWebDriver chromedriver = new ChromeDriver(options);
           
            driver = chromedriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        public void SafeClick(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", element);
            element.Click();
        }

        public void SafeSendKeys(By locator, string text)
        {
            IWebElement element = driver.FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", element);
            element.SendKeys(text);
        }
    }
}