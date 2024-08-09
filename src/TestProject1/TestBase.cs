using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using PageObjectModel.Flows;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace TestProject1
{
    public class TestBase
    {
        public IWebDriver driver;
        private string preferredBrowser = "chrome";
        LoginPage lPage;
        LoginFlow lFlow;
        public TestBase()
        {
            driver = WhichBrowserToLaunch(preferredBrowser);
            lPage = new LoginPage(driver);
            lFlow = new LoginFlow(lPage);
        }

        //private ExtentReports _report;
        //private ExtentTest _test;
        //_test = _report.CreateTest(TestContext.CurrentContext.Test.Name);

        [SetUp]
        public void LoginSetup()
        {
            ExtentReportCreation.CreateTest(TestContext.CurrentContext.Test.MethodName);
            lFlow.NavigateToWebApplication();
            lFlow.LoginWithValidCredentials();
        }

        //[Test]
        //public void NoActionTest()
        //{
        //    TakeScreenShot();
        //    Assert.AreEqual("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index", driver.Url);
        //}

        [TearDown] 
        public void LogoutTearDown()
        {
            LoginPage lPage = new LoginPage(driver);
            LoginFlow lFlow = new LoginFlow(lPage);
            lFlow.LogoutFromUser(); 
            ExtentReportCreation.EndReporting();
        }
        [OneTimeTearDown]
        public void OneTimeLogout()
        {
            driver.Close();
            driver.Quit();
        }

        private IWebDriver WhichBrowserToLaunch(string browser)
        {
            if(browser == "chrome")
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                ChromeOptions co = new ChromeOptions();
                co.AddArgument("--incognito");
                co.AddArgument("--start-maximized");
                driver = new ChromeDriver(co);
                return driver;
            }
            else if(browser == "edge")
            {
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                EdgeOptions eo = new EdgeOptions();
                eo.AddArgument("--incongnito");
                driver = new EdgeDriver();
                return driver;
            }
            else if(browser == "firefox")
            {
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();
                return driver;
            }
            else
            {
                Console.WriteLine("Invalid browser name");
                return driver;
            }
        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch(testStatus)
            {
                case TestStatus.Failed:
                    ExtentReportCreation.LogFail($"The test has Failed {message}"); break;
                case TestStatus.Passed:
                    ExtentReportCreation.LogPass($"The test has Passed {message}"); break;
                case TestStatus.Skipped:
                    ExtentReportCreation.LogInfo($"The test was Skipped {message}"); break;
                default:
                    break;
            }
            ExtentReportCreation.LogScreenShot("Taking Screenshot", TakeScreenShot());
            ExtentReportCreation.LogInfo("Ending the test");

        }

        public string TakeScreenShot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            StackTrace stackTrace = new StackTrace();
            string title = stackTrace.GetFrame(1).GetMethod().Name;
            string Runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            string screenshotfilename = "D:\\Screenshots\\" + Runname + ".jpg";
            ss.SaveAsFile(screenshotfilename);
            var image = ss.AsBase64EncodedString;
            return image;
        }

        //public void ExtentReport()
        //{
        //    StackTrace stackTrace = new StackTrace();
        //    string title = stackTrace.GetFrame(1).GetMethod().Name;
        //    string runName = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
        //    var projectPath = "D:\\ExtentReport\\";
        //    Directory.CreateDirectory(projectPath.ToString() + "Reports");
        //    //var reportPath = projectPath + "Reports\\" + runName +".html";
        //    var reportPath = projectPath + "Reports\\Test.html";
        //    var htmlReporter = new ExtentSparkReporter(reportPath);
        //    htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
        //    htmlReporter.Config.DocumentTitle = "Test Automation Framework";
        //    _report = new ExtentReports();
        //    _report.AttachReporter(htmlReporter);
        //    _report.AddSystemInfo("Username",username);

        //}
    }
}
