using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace DemoQA_Automation
{
    [TestClass]
    public class ExecutionTests : CorePage
    {
        [TestInitialize]
        public void Setup()
        {
            SeleniumInit();
            bool isHeadless = bool.Parse(ConfigurationManager.AppSettings["Headless"] ?? "false");
            if (!isHeadless)
            {
                driver.Manage().Window.Maximize();
            }
        }

        [TestMethod]
        public void Elements()
        {
            ElementPage element = new ElementPage();
            element.TextBox();
            element.CheckBox();
            element.RadioButton();
            element.WebTables();
            element.Buttons();
            element.Links();
            element.BrokenLinksImages();
            element.UploadandDownload();
            element.DynamicProperties();
        }
        [TestMethod]
        public void Forms()
        { 
           FormsPage form = new FormsPage();
            form.PracticeForm();
        }
        [TestMethod]
        public void AFW()
        {
            AlertFrameandWindows awf = new AlertFrameandWindows();
      
            awf.Alerts();
            awf.Frames();
            awf.NestedFrames();
            awf.ModalDialogs();
            awf.BrowserWindows();
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}