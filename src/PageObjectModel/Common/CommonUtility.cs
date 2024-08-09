using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Common
{
    public static class CommonUtility
    {
        static Actions act;
        
        public static void ActionMoveToElement(IWebDriver driver, IWebElement element)
        {
            act = new Actions(driver);
            act.MoveToElement(element);
        }

        public static void FluentWait()
        {

        }
    }
}
