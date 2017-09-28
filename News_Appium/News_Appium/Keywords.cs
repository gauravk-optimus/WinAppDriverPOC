using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using System.Configuration;
using OpenQA.Selenium;

namespace News_Appium
{
   public class Keywords
    {
        private static NLog.Logger _logger = NLog.LogManager.GetLogger("Test Execution Logs");

        //Write text in textbox
        public static void SendTextInTextBox(string data, string element)
        {
            try
            {
                _logger.Info("Finding "+element);
                WindowsElement ele = NewsTest.NewsApp.FindElementByName(element);
                _logger.Info("Entering " + data);
                ele.SendKeys(data);
                _logger.Info(data + " entered");
            }
            catch(Exception e)
            {
                _logger.Info("Unable to enter " + data);
                _logger.Fatal(e);
                //e.Message.ToString();
                throw new Exception();
            }
        }

        //Click on element
        public static void ClickByText(string element)
        {            
            try
            {
                _logger.Info("Clicking on " + element + " button");
                NewsTest.NewsApp.FindElementByName(element).Click();
            }
            catch (Exception e)
            {
                _logger.Info("Unable to click on " + element);
                _logger.Fatal(e);
                throw new Exception();
            }
        }
        //Read text
        public static string ReadText(string element)
        {
            try
            {
                _logger.Info("Finding " + element);
                WindowsElement ele = NewsTest.NewsApp.FindElementByName(Locators.todayHeading_Name);
                _logger.Info("Reading text");
                string text =  ele.Text.ToString();
                _logger.Info("Text is "+text);
                return text;
            }
            catch (Exception e)
            {
                _logger.Info("Unable to read");
                _logger.Fatal(e);
                throw new Exception();
            }
        }
        public static void TakeScreenShot(string filename, WindowsDriver<WindowsElement> driver)
        {
            //Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            //file.SaveAsFile(@"C:\image.png", ImageFormat.Png);

            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenShot = screenshotDriver.GetScreenshot();
            screenShot.SaveAsFile("D:\\SampleApp\\News_Appium\\TestReports\\" + filename + ".jpeg", System.Drawing.Imaging.ImageFormat.Gif);
        }
    }
}

