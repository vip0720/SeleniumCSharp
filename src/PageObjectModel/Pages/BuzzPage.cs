using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Pages
{
    public class BuzzPage
    {
        public IWebDriver _driver;

        public BuzzPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement BuzzMenu
        {
            get
            {
                return _driver.FindElement(By.XPath("//span[@class='oxd-text oxd-text--span oxd-main-menu-item--name' and text() ='Buzz']"));
            }
        }

        public IWebElement BuzzPostBox
        {
            get
            {
                return _driver.FindElement(By.XPath("//textarea[@class='oxd-buzz-post-input']"));
            }
        }

        public IWebElement SaveButton1
        {
            get
            {
                return _driver.FindElement(By.XPath("//button[@type='submit']"));
            }
        }

        public IWebElement PostedText
        {
            get
            {
                return _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p orangehrm-buzz-post-body-text' and text()='"));// + postValue + "']"));
            }
        }

        public IWebElement LikeButton
        {
            get
            {
                return _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p orangehrm-buzz-stats-active']"));
            }
        }
    }
}
