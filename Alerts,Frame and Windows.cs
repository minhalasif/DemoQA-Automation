using OpenQA.Selenium;
using System;
using System.Linq;

namespace DemoQA_Automation
{
    public class AlertFrameandWindows : CorePage
    {
        public void Alerts()
        {
            driver.Url = "https://demoqa.com/alerts";
            SafeClick(By.Id("alertButton"));
            System.Threading.Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            SafeClick(By.Id("timerAlertButton"));
            System.Threading.Thread.Sleep(6000);
            driver.SwitchTo().Alert().Accept();
            SafeClick(By.Id("confirmButton"));
            System.Threading.Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            SafeClick(By.Id("promtButton"));
            System.Threading.Thread.Sleep(2000);
            driver.SwitchTo().Alert().SendKeys("Minhal Asif");
            driver.SwitchTo().Alert().Accept();
        }
        public void Frames()
        {
            driver.Url = "https://demoqa.com/frames";
            driver.SwitchTo().Frame("frame1");
            driver.SwitchTo().DefaultContent();
        }
        public void NestedFrames()
        {
            driver.Url = "https://demoqa.com/nestedframes";
            driver.SwitchTo().Frame(0);
            string parentText = driver.FindElement(By.TagName("body")).Text;
            driver.SwitchTo().Frame(0);
            string childText = driver.FindElement(By.TagName("body")).Text;
            driver.SwitchTo().DefaultContent();
        }
        public void ModalDialogs()
        {
            driver.Url = "https://demoqa.com/modal-dialogs";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("showSmallModal")).Click();
            var smallModalText = driver.FindElement(By.Id("example-modal-sizes-title-sm")).Text;
            Console.WriteLine($"Small Modal Text: {smallModalText}");
            driver.FindElement(By.Id("closeSmallModal")).Click();
            driver.FindElement(By.Id("showLargeModal")).Click();
            var largeModalText = driver.FindElement(By.Id("example-modal-sizes-title-lg")).Text;
            Console.WriteLine($"Large Modal Text: {largeModalText}");
            driver.FindElement(By.Id("closeLargeModal")).Click();
        }
        public void BrowserWindows()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            string originalTab = driver.CurrentWindowHandle;
            SafeClick(By.Id("tabButton"));
            SwitchToNewWindowAndClose(originalTab);
            SafeClick(By.Id("windowButton"));
            SwitchToNewWindowAndClose(originalTab);
            SafeClick(By.Id("messageWindowButton"));
            SwitchToNewWindowAndClose(originalTab);
        }
        private void SwitchToNewWindowAndClose(string originalTab)
        {
            System.Threading.Thread.Sleep(1000);
            if (driver.WindowHandles.Count > 1)
            {
                string newHandle = driver.WindowHandles.First(h => h != originalTab);
                driver.SwitchTo().Window(newHandle);
                driver.Close();
                driver.SwitchTo().Window(originalTab);
            }
        }
    }
}