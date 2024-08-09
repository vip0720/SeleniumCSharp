using ICSharpCode.SharpZipLib.Core;
using OpenQA.Selenium;
using PageObjectModel.Flows;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Tests
{
    public class LoginWithInvalidUser: TestBase
    {
        [Test, Category("Smoke"), Category("Login")]
        public void LoginUsingInvalidUser()
        {
            ExtentReportCreation.LogInfo("Starting Test - Login with invalid credentials");

            LoginPage loginPage = new LoginPage(driver);
            LoginFlow loginFlow = new LoginFlow(loginPage);
            loginFlow.LogoutFromUser();
            loginFlow.LoginWithInvalidCredentials();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var invalidTextMsg = driver.FindElement(By.XPath("//p[@class=\"oxd-text oxd-text--p oxd-alert-content-text\"]")).Text;
            Assert.AreEqual("Invalid credentials", invalidTextMsg);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            loginFlow.LoginWithValidCredentials();
        }
    }
}
