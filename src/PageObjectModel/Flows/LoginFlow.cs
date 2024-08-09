using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Flows
{
    public class LoginFlow
    {

        private string url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        private string username = "Admin";
        private string password = "admin123";
        public LoginPage _page;
        public LoginFlow(LoginPage page) 
        {
            _page = page;
        }

        public void NavigateToWebApplication()
        {
            _page._driver.Navigate().GoToUrl(url);
            _page._driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public void LoginWithValidCredentials()
        {
            _page.UserName.SendKeys(username);
            _page.Password.SendKeys(password);
            _page.LoginButton.Click();
            _page._driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public void LoginWithCustomUserCredentials(string custUserName, string custPassword)
        {
            _page.UserName.SendKeys(custUserName);
            _page.Password.SendKeys(custPassword);
            _page.LoginButton.Click();
            _page._driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void LoginWithInvalidCredentials()
        {
            List<string> credentials = new List<string>() { "AB", "CD", "EF", "GH", "IJ" };
            credentials.Add("KL");

            StringBuilder sb = new StringBuilder();
            // foreach(var cred in credentials) => sb.Append(cred);
            foreach (var cred in credentials)
            {
                sb.Append(cred);
            }
            credentials.Insert(5,"MN");
            credentials.Remove("GH");
            credentials.RemoveAt(2);
            _page.UserName.SendKeys(sb.ToString());
            sb.Clear();
            foreach (var cred in credentials)
            {
                sb.Append(cred);
            }
            _page.Password.SendKeys(sb.ToString());
            _page.LoginButton.Click();

        }

        public void LogoutFromUser()
        {
            _page.ProfileDropDownForLogout.Click();
            _page.LogoutButton.Click();
        }

        public void ClickMainMenuCollapseButton()
        {
            _page.MainMenuDisplay("left").Click();
        }

        public void ClickMainMenuExpandButton()
        {
            _page.MainMenuDisplay("right").Click();
        }

        public void EnterValueInSearchBox(string searchText)
        {
            _page.SearchBox.SendKeys(searchText);
        }

        public void ClickAdminLink()
        {
            _page.MenuLinkNavigation("Admin").Click();
        }

        public void ClickPIMLink()
        {
            _page.MenuLinkNavigation("PIM").Click();
        }

        public void ClickLeaveLink()
        {
            _page.MenuLinkNavigation("Leave").Click();
        }

        public void ClickTimeLink()
        {
            _page.MenuLinkNavigation("Time").Click();
        }

        public void ClickRecruitmentLink()
        {
            _page.MenuLinkNavigation("Recruitment").Click();
        }

        public void ClickMyInfoLink()
        {
            _page.MenuLinkNavigation("My Info").Click();
        }

        public void ClickPerformanceLink()
        {
            _page.MenuLinkNavigation("Performance").Click();
        }

        public void ClickDashboardLink()
        {
            _page.MenuLinkNavigation("Dashboard").Click();
        }

        public void ClickDirectoryLink()
        {
            _page.MenuLinkNavigation("Directory").Click();
        }

        public void ClickMaintenanceLink()
        {
            _page.MenuLinkNavigation("Maintenance").Click();
        }

        public void ClickClaimLink()
        {
            _page.MenuLinkNavigation("Claim").Click();
        }

        public void ClickBuzzLink()
        {
            _page.MenuLinkNavigation("Buzz").Click();
        }



    }
}
