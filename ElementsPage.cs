using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
namespace DemoQA_Automation

{
    public class ElementPage : CorePage
    {
        public void TextBox()
        {
            driver.Url = "https://demoqa.com/text-box";
            SafeSendKeys(By.Id("userName"), "Minhal Asif");
            SafeSendKeys(By.Id("userEmail"), "minhal@123.com");
            SafeSendKeys(By.Id("currentAddress"), "abc");
            SafeSendKeys(By.Id("permanentAddress"), "xyz");
            SafeClick(By.Id("submit"));
        }

        public void CheckBox()

        {
            driver.Url = "https://demoqa.com/elements";
            driver.Manage().Window.Maximize();
            SafeClick(By.XPath("//span[text()='Check Box']"));
        }

        public void RadioButton()
        {
            driver.Url = "https://demoqa.com/radio-button";
            SafeClick(By.XPath("//label[@for='yesRadio']"));
            SafeClick(By.XPath("//label[@for='impressiveRadio']"));
        }

        public void WebTables()
        {
            driver.Url = "https://demoqa.com/webtables";
            SafeClick(By.Id("addNewRecordButton"));
            SafeSendKeys(By.Id("firstName"), "Minhal");
            SafeSendKeys(By.Id("lastName"), "Asif");
            SafeSendKeys(By.Id("userEmail"), "minhal@123.com");
            SafeSendKeys(By.Id("age"), "23");
            SafeSendKeys(By.Id("salary"), "45000");
            SafeSendKeys(By.Id("department"), "QA");
            SafeClick(By.Id("submit"));
        }

        public void Buttons()
        {
            driver.Url = "https://demoqa.com/buttons";
            Actions actions = new Actions(driver);
            IWebElement clickMeBtn = driver.FindElement(By.XPath("(//button[text()='Click Me'])[1]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", clickMeBtn);
            clickMeBtn.Click();
            IWebElement doubleClickBtn = driver.FindElement(By.Id("doubleClickBtn"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", doubleClickBtn);
            actions.DoubleClick(doubleClickBtn).Perform();
            IWebElement rightClickBtn = driver.FindElement(By.Id("rightClickBtn"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", rightClickBtn);
            actions.ContextClick(rightClickBtn).Perform();
        }
        public void Links()
        {
            driver.Url = "https://demoqa.com/links";
            string originalTab = driver.CurrentWindowHandle;
            SafeClick(By.Id("simpleLink"));
            SwitchBackIfNewTabOpened(originalTab);
            SafeClick(By.Id("dynamicLink"));
            SwitchBackIfNewTabOpened(originalTab);
            SafeClick(By.Id("created"));
            SafeClick(By.Id("no-content"));
            SafeClick(By.Id("moved"));
            SafeClick(By.Id("bad-request"));
            SafeClick(By.Id("unauthorized"));
            SafeClick(By.Id("forbidden"));
            SafeClick(By.Id("invalid-url"));
        }
        private void SwitchBackIfNewTabOpened(string originalTab)
        {
            if (driver.WindowHandles.Count > 1)
            {
                foreach (var handle in driver.WindowHandles)
                {
                    if (handle != originalTab)
                    {
                        driver.SwitchTo().Window(handle);
                        driver.Close();  
                    }
                }
                driver.SwitchTo().Window(originalTab);  
            }
        }


        public void BrokenLinksImages()
        {
            driver.Url = "https://demoqa.com/broken";
            SafeClick(By.XPath("//a[text()='Click Here for Valid Link']"));
        }
        public void UploadandDownload()
        {
            driver.Url = "https://demoqa.com/upload-download";
            SafeClick(By.Id("downloadButton"));
            IWebElement uploadInput = driver.FindElement(By.Id("uploadFile"));
            uploadInput.SendKeys(@"C:\Users\asiffmin\Downloads\scenery.webp");
        }
        public void DynamicProperties()
        {
            driver.Url = "https://demoqa.com/dynamic-properties";
            System.Threading.Thread.Sleep(6000);
            SafeClick(By.Id("enableAfter"));
            SafeClick(By.Id("colorChange"));
            SafeClick(By.Id("visibleAfter"));
        }
    }
}