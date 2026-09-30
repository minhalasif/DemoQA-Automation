using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoQA_Automation
{
    public class FormsPage : CorePage
    {
        public void PracticeForm()
        {
            driver.Url = "https://demoqa.com/automation-practice-form";
            SafeSendKeys(By.Id("firstName"), "Minhal");
            SafeSendKeys(By.Id("lastName"), "Asif");
            SafeSendKeys(By.Id("userEmail"), "minhal@123.com");
            SafeClick(By.XPath("//label[text()='Female']"));
            SafeSendKeys(By.Id("userNumber"), "0300123456");
            SetDateOfBirth("15", "May", "2000");
            IWebElement subjectsInput = driver.FindElement(By.Id("subjectsInput"));
            subjectsInput.SendKeys("Maths");
            subjectsInput.SendKeys(Keys.Enter);
            SafeClick(By.XPath("//label[text()='Sports']"));
            SafeClick(By.XPath("//label[text()='Reading']"));
            IWebElement uploadPic = driver.FindElement(By.Id("uploadPicture"));
            uploadPic.SendKeys(@"C:\Users\asiffmin\Downloads\scenery.webp");
            SafeSendKeys(By.Id("currentAddress"), "House 123, Lahore");
            SafeClick(By.Id("state"));
            SafeClick(By.XPath("//div[text()='NCR']"));
            SafeClick(By.Id("city"));
            SafeClick(By.XPath("//div[text()='Delhi']"));
            SafeClick(By.Id("submit"));
        }
        private void SetDateOfBirth(string day, string month, string year)
        {
            SafeClick(By.Id("dateOfBirthInput"));
            IWebElement yearDropdown = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            var yearSelect = new SelectElement(yearDropdown);
            yearSelect.SelectByText(year);
            IWebElement monthDropdown = driver.FindElement(By.ClassName("react-datepicker__month-select"));
            var monthSelect = new SelectElement(monthDropdown);
            monthSelect.SelectByText(month);
            SafeClick(By.XPath($"//div[contains(@class,'react-datepicker__day') and not(contains(@class,'outside-month')) and text()='{day}']"));
        }
    }
}