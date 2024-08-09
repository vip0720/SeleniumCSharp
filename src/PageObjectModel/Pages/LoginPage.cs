using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Pages
{
    public class LoginPage
    {
        public IWebDriver _driver;
        public LoginPage(IWebDriver driver) 
        { 
            _driver = driver;
        }

        public IWebElement UserName
        {
            get
            {
                return _driver.FindElement(By.Name("username"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return _driver.FindElement(By.Name("password"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return _driver.FindElement(By.XPath("//button[@class=\"oxd-button oxd-button--medium oxd-button--main orangehrm-login-button\"]"));
            }
        }

        public IWebElement ProfileDropDownForLogout
        {
            get
            {
                return _driver.FindElement(By.XPath("//i[@class=\"oxd-icon bi-caret-down-fill oxd-userdropdown-icon\"]"));
            }
        }

        public IWebElement LogoutButton
        {
            get
            {
                return _driver.FindElement(By.LinkText("Logout"));
            }
        }

        public IWebElement MainMenuDisplay(string direction)
        {
            return _driver.FindElement(By.XPath("//i[@class='oxd-icon bi-chevron-"+ direction +"']"));
        }

        public IWebElement SearchBox
        {
            get
            {
                return _driver.FindElement(By.XPath("//input[@class='oxd-input oxd-input--active' and @placeholder='Search']"));
            }
        }

        public IWebElement MenuLinkNavigation(string pageName)
        {
            return _driver.FindElement(By.XPath("//a[@class='oxd-main-menu-item']/span[text()='"+ pageName +"']"));
        }
        
    }
}
