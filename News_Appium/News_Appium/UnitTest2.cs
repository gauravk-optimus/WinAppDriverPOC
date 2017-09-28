using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using RelevantCodes.ExtentReports;

namespace News_Appium
{
    [TestClass]
    //TODO change UnitTest1.cs to other name like in java class and class file name should be same
    //TODO reporting using report Unit

    public class NewsTest2
    {       
        //WinAppDriverUri
        public static string WindowsApplicationDriverUrl = System.Configuration.ConfigurationManager.AppSettings["WindowsApplicationDriverUrl"]; //"http://127.0.0.1:4723";
        //Extent report object
        ExtentReports extent = new ExtentReports("D:\\SampleApp\\News_Appium\\TestReports\\TestReport.html");

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

       // [TestMethod]
        [TestCategory("Nightly")]
        public void OtherTestCase()
        {
            //start test
            var test = extent.StartTest("OpenNewsApp", "This test case open and verifies the 'News' app");
            //log info in extent report
            test.Log(LogStatus.Info, "OpenNewsApp extent report info");
            try
            {
                _logger.Info("Test");
                //TODO testcase
            }
            catch (Exception e)
            {
                string err = e.InnerException.Message.ToString();
                _logger.Info("OpenNewsApp Test Case Failed");
                _logger.Error(e, e.Message);
                Assert.Fail();
            }

            Keywords.TakeScreenShot("Error Screenshot", NewsApp);
            test.Log(LogStatus.Info, "Screenshot -" + test.AddScreenCapture("D:\\SampleApp\\News_Appium\\TestReports\\Error Screenshot.jpeg"));
            extent.EndTest(test);
            extent.Flush();     
        }
    }
}
