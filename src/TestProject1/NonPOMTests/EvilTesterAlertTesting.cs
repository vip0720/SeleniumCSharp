using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.NonPOMTests
{
    public class EvilTesterAlertTesting
    {
        public WebDriver driver;

        [SetUp]
        public void SetupMethod()
        {
            Console.WriteLine("SetupMethod");
        }

        [Test]
        public void ActionTesting()
        {
            string url = "https://testpages.eviltester.com/styled/alerts/alert-test.html";
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("alertexamples")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.SwitchTo().Alert().Accept();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("confirmexample")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.Id("confirmexample")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.SwitchTo().Alert().Dismiss();
            driver.FindElement(By.Id("promptexample")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.SwitchTo().Alert().SendKeys("New text");
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.Id("promptexample")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.SwitchTo().Alert().SendKeys("New text");
            driver.SwitchTo().Alert().Dismiss();


        }

        [TearDown]
        public void TearDownMethod()
        {
            driver.Close();
            driver.Quit();
        }


    }
}
