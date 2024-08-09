using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using PageObjectModel.Pages;
using PageObjectModel.Flows;

namespace TestProject1.Tests
{
    public class FirstTest
    {
        public WebDriver driver;
        public void MyExplicitWait(string identifier, int typeOfIdentifier)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            if (typeOfIdentifier == 1)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(identifier)));
            }
            else if (typeOfIdentifier == 2)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(identifier)));
            }
            else
            {
                Console.WriteLine("Type of identifier is not defined");
            }
        }

        public void MyAction()
        {
            //Action action = new Action(driver);
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //Acquisition acq = new Acquisition();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LoginPage loginPage = new LoginPage(driver);
            LoginFlow loginFlow = new LoginFlow(loginPage);
            loginFlow.LoginWithValidCredentials();

        }

        [Test, Order(1)]
        public void Login()
        {
            Assert.AreEqual("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index", driver.Url);

        }
        [Test, Order(4)]
        public void LoginUsingInvalidUser()
        {
            driver.FindElement(By.XPath("//i[@class=\"oxd-icon bi-caret-down-fill oxd-userdropdown-icon\"]")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LoginPage loginPage = new LoginPage(driver);
            LoginFlow loginFlow = new LoginFlow(loginPage);
            loginFlow.LoginWithInvalidCredentials();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            var invalidTextMsg = driver.FindElement(By.XPath("//p[@class=\"oxd-text oxd-text--p oxd-alert-content-text\"]")).Text;
            Assert.AreEqual("Invalid credentials", invalidTextMsg);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            loginFlow.LoginWithValidCredentials();
        }

        [Test, Order(2)]
        public void Buzz()
        {
            DateTime dateTime = DateTime.Now.Date;
            var postValue = dateTime + "\nMy Name is VIP. \n This is test automation run. \n Thank you for this website. \n";
            string anotherValue = "The quick brown fox jumps over the lazy dog";
            BuzzPage buzzPage = new BuzzPage(driver);
            BuzzFlow buzzFlow = new BuzzFlow(buzzPage);

            buzzFlow.ClickBuzzMenu();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            buzzFlow.EnterBuzzPostBox();
            buzzFlow.EnterBuzzPostBox(postValue);
            buzzFlow.EnterBuzzPostBox(anotherValue.ToCharArray());
            buzzFlow.EnterBuzzPostBox(5);
            buzzFlow.EnterBuzzPostBox("Act", "Cat");
            buzzFlow.EnterBuzzPostBox("Mark", "Kumar");
            buzzFlow.EnterBuzzPostBox(anotherValue, true);
            buzzFlow.EnterBuzzPostBox(postValue, false);
            buzzFlow.ClickSaveButton1();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            //var postFeedXpath = driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p orangehrm-buzz-post-body-text' and text()='" + postValue + "']"));
            //var expectedValue = dateTime + "\r\nMy Name is VIP. \r\n This is test automation run. \r\n Thank you for this website.";
            //Assert.AreEqual(expectedValue, postFeedXpath.Text);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Id("heart-svg")).Click();
            var likeXpath = driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p orangehrm-buzz-stats-active']"));
            //Assert.AreEqual("1 Like", likeXpath.Text);

        }

        [Test, Order(3)]
        public void PIM()
        {
            driver.FindElement(By.XPath("//a[@href='/web/index.php/pim/viewPimModule']")).Click();
            driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']")).Click();
            MyExplicitWait("//h6[@class='oxd-text oxd-text--h6 orangehrm-main-title' and text()='Add Employee']", 2);
            driver.FindElement(By.Name("firstName")).SendKeys("Sachin");
            driver.FindElement(By.Name("middleName")).SendKeys("Sachin");
            driver.FindElement(By.Name("lastName")).SendKeys("Sachin");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            var pageTitle = "//h6[text()='Personal Details' and @class='oxd-text oxd-text--h6 orangehrm-main-title']";
            MyExplicitWait(pageTitle.ToString(), 2);
            IWebElement titleAssert = driver.FindElement(By.XPath("//h6[text()='Personal Details' and @class='oxd-text oxd-text--h6 orangehrm-main-title']"));
            Assert.IsTrue(titleAssert.Displayed);
            var dropDown = driver.FindElement(By.XPath("//label[@class='oxd-label' and text()='Nationality']/parent::div/following-sibling::div//div[@class='oxd-select-text-input']"));

            Actions action = new Actions(driver);
            action.ScrollToElement(driver.FindElement(By.XPath("//p[text()=' * Required']"))).Perform();

            dropDown.Click();
            driver.FindElement(By.XPath("//div[@role='option']//span[text()='Indian']")).Click();

            Assert.AreEqual("Indian", dropDown.Text);
            var maritialStatus = driver.FindElement(By.XPath("//label[@class='oxd-label' and text()='Marital Status']/parent::div/following-sibling::div//div[@class='oxd-select-text-input']"));
            maritialStatus.Click();
            driver.FindElement(By.XPath("//div[@class='oxd-select-dropdown --positon-bottom']/div/span[text()='Single']")).Click();

            Assert.AreEqual("Single", maritialStatus.Text);
            driver.FindElement(By.XPath("//label[@class='oxd-label' and text()='Date of Birth']/parent::div/following-sibling::div//input[@class='oxd-input oxd-input--active']"))
                .SendKeys("1989-04-03");
            driver.FindElement(By.XPath("//parent::label[text()='Male']/span")).Click();
            //driver.FindElement(By.XPath("//button[@type='submit']/preceding-sibling::p[@class='oxd-text oxd-text--p orangehrm-form-hint']")).Click();
            driver.FindElement(By.XPath("//p[text()=' * Required']/following-sibling::button[@type='submit']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3.0);
            IWebElement toastMessage = driver.FindElement(By.Id("oxd-toaster_1"));
            //MyExplicitWait(toastMessage.ToString(), 2);
            Assert.IsTrue(toastMessage.Displayed);

        }

        [TearDown]
        public void logout()
        {
            driver.FindElement(By.XPath("//i[@class=\"oxd-icon bi-caret-down-fill oxd-userdropdown-icon\"]")).Click();
            driver.FindElement(By.XPath("//a[@class=\"oxd-userdropdown-link\"]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Close();
            driver.Quit();
        }
    }
}
