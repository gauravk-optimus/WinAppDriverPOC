using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using RelevantCodes.ExtentReports;
using System.Globalization;

namespace News_Appium
{
    [TestClass]
    //TODO change UnitTest1.cs to other name like in java class and class file name should be same

    public class NewsTest
    {
       
        //WinAppDriverUri
        public static string WindowsApplicationDriverUrl = System.Configuration.ConfigurationManager.AppSettings["WindowsApplicationDriverUrl"]; //"http://127.0.0.1:4723";
        //Extent report object
       
        ExtentReports extent = new ExtentReports("D:\\SampleApp\\News_Appium\\TestReports\\TestReport.html", false);
        
        //WindowsDiver objects
        public static WindowsDriver<WindowsElement> NewsApp;
        protected static WindowsDriver<WindowsElement> DesktopSession;

        //Get the "Test Execution Logs" from NLog.config
        private NLog.Logger _logger = NLog.LogManager.GetLogger("Test Execution Logs");
        [ClassInitialize]
        public static void Setup(TestContext context)
        {

            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", "Microsoft.BingNews_8wekyb3d8bbwe!AppexNews");
            NewsApp = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(NewsApp);
            DesiredCapabilities desktopCapabilities = new DesiredCapabilities();
            desktopCapabilities.SetCapability("app", "Root");
            DesktopSession = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), desktopCapabilities);
            Assert.IsNotNull(DesktopSession);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            NewsApp.Quit();
        }

        [TestMethod]
        [TestCategory("Nightly")]
        public void OpenNewsApp()
        {
            var test = extent.StartTest("OpenNewsApp", "This test case open and verifies the 'News' app");
            try
            {
                test.Log(LogStatus.Info, "Execution of OpenNewsApp test case started");
                _logger.Info("Locating the Today Heading");
                test.Log(LogStatus.Info, "Locating the Today Heading");
                _logger.Info("Locating the Today Heading");
                string text = Keywords.ReadText(Locators.todayHeading_Name);
                Assert.AreEqual("Today", text);
            }
            catch (Exception e)
            {
                string err = e.InnerException.Message.ToString();
                test.Log(LogStatus.Info, "OpenNewsApp Test Case Failed");
                _logger.Info("OpenNewsApp Test Case Failed");
                _logger.Error(e, e.Message);
                Assert.Fail();
            }

            Keywords.TakeScreenShot("Error Screenshot", NewsApp);
            test.Log(LogStatus.Info, "Screenshot link" + test.AddScreenCapture("D:\\SampleApp\\News_Appium\\TestReports\\Error Screenshot.jpeg"));
            extent.EndTest(test);
            extent.Flush();
        }

        [TestMethod]
        public void SearchNews()
        {          
            var test = extent.StartTest("SearchNews", "This test case write the string in search textbox");
            test.Log(LogStatus.Info, "Execution of SearchNews test case started");
            _logger.Info("Execution of SearchNews test case started");
            try
            {
                NewsApp.Manage().Window.Maximize();
                test.Log(LogStatus.Info, "Clicking the search icon");
                _logger.Info("Clicking the search icon");
                Keywords.ClickByText(Locators.searchIcon_Name);
                test.Log(LogStatus.Info, "Entering search string");
                _logger.Info("Entering search string");
                Keywords.SendTextInTextBox(TestData.searchString, Locators.searchIcon_Name);          
            }
            catch (Exception e)
            {
                test.Log(LogStatus.Info, "SearchNews Test Case Failed");
                _logger.Info("SearchNews Test Case Failed");
                _logger.Error(e, e.Message);
                Assert.Fail();
            }
            Keywords.TakeScreenShot("SearchNews Screenshot", NewsApp);
            test.Log(LogStatus.Info, "Screenshot -" + test.AddScreenCapture("D:\\SampleApp\\News_Appium\\TestReports\\SearchNews Screenshot.jpeg"));
            extent.EndTest(test);
            extent.Flush();
        }
    }
}
