using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace PlanitTechnicalAssessment.TestFrameWork
{
    /// <summary>
    /// Config all test related setup ie application url, browser type, driver, wait types
    /// and everything that needs to be configured before tests can be started
    /// </summary>
    public class TestConfig
    {
        public static IWebDriver driver;

        public string BrowserType { get; set; }

        public string WebApplicationUrl { get; set; }
        public string PathToScreenshot { get; set; }


        public void InitializeTestConfig()
        {
            if (Hooks.config.BrowserType == "Chrome")
            {
                driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            }
            else if (Hooks.config.BrowserType == "firefox")
            {
                driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
            }

            WebApplicationUrl = Hooks.config.WebApplicationUrl;
        }


        /// <summary>
        /// Implicit wait, allows user to specify their own convinient wait time or can be relied on the default timeout
        /// </summary>
        /// <param name="timeoutInMilliseconds"></param>
        public void ImplicitWait(int timeoutInMilliseconds = 15)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timeoutInMilliseconds);
        }


        /// <summary>
        /// Fluent wait allows user to wait for any specific element where user can specy timeout as well the polling interval and the 
        /// element whcih needs to be loaded
        /// </summary>
        /// <param name="element"></param>
        /// <param name="timeout"></param>
        /// <param name="pollingintervalInSeconds"></param>
        public void FluentWait(IWebElement element, int timeout = 30, int pollingintervalInSeconds = 1)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(30);
            fluentWait.PollingInterval = TimeSpan.FromSeconds(1);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            fluentWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            fluentWait.IgnoreExceptionTypes(typeof(System.NullReferenceException));

            fluentWait.Message = "Element to be seached not found";
            fluentWait.Until(x => !element.Size.IsEmpty);
            element.Click();
        }

        public void DisposeTestData()
        {
            driver.Quit(); //dispse driver
        }


        /// <summary>
        /// Take screenshot if tes does not pass
        /// create directory C:\\Temp if does not exist and save screenshot there
        /// </summary>
        public void TakeScreenshot()
        {
            var pathToScreenshotDirectory = Hooks.config.PathToScreenshot;

            if (!Directory.Exists(pathToScreenshotDirectory))
            {
                Directory.CreateDirectory(pathToScreenshotDirectory);
            }
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(pathToScreenshotDirectory + "\\" + TestContext.CurrentContext.Test.Name + ".png", ScreenshotImageFormat.Png);
        }

        public void cleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                TakeScreenshot();
            }
            DisposeTestData();
        }
    }
}
