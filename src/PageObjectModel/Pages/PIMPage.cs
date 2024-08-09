using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V124.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Pages
{
    public class PIMPage
    {
        public IWebDriver _driver;

        public PIMPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement PIMMenu
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[@href='/web/index.php/pim/viewPimModule']"));
            }
        }

        // Add employee personal details page

        public IWebElement AddEmployeeButtonEmployeeListPage
        {
            get
            {
                return _driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']"));
            }
        }

        public IWebElement EmployeeListMenuButton
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[@class='oxd-topbar-body-nav-tab-item' and text()='Employee List']"));
            }
        }

        public IWebElement AddEmployeeMenuButton
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[@class='oxd-topbar-body-nav-tab-item' and text()='Add Employee']"));
            }
        }

        public IWebElement ReportsMenuButton
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[@class='oxd-topbar-body-nav-tab-item' and text()='Reports']"));
            }
        }

        public IWebElement PersonalDetailsLink
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[text()='Personal Details']"));
            }
        }

        public IWebElement ContactDetailsLink
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[text()='Contact Details']"));
            }
        }

        public IWebElement EmergencyContactsLink
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[text()='Emergency Contacts']"));
            }
        }

        public IWebElement DependentsLink
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[text()='Dependents']"));
            }
        }

        public IWebElement ImmigrationLink
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[text()='Immigration']"));
            }
        }

        public IWebElement JobLink
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[text()='Job']"));
            }
        }

        public IWebElement SalaryLink
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[text()='Salary']"));
            }
        }

        public IWebElement TaxExemptionsLink
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[text()='Tax Exemptions']"));
            }
        }

        public IWebElement ReportToLink
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[text()='Report-to']"));
            }
        }

        public IWebElement QualificationsLink
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[text()='Qualifications']"));
            }
        }

        public IWebElement MembershipsLink
        {
            get
            {
                return _driver.FindElement(By.XPath("//a[text()='Memberships']"));
            }
        }

        public IWebElement EmpFirstName
        {
            get
            {
                return _driver.FindElement(By.Name("firstName"));
            }
        }

        public IWebElement EmpMiddleName
        {
            get
            {
                return _driver.FindElement(By.Name("middleName"));
            }
        }

        public IWebElement EmpLastName
        {
            get
            {
                return _driver.FindElement(By.Name("lastName"));
            }
        }
        public IWebElement SaveButton
        {
            get
            {
                return _driver.FindElement(By.XPath("//button[@type='submit']"));
            }
        }
        public IWebElement CustomFieldsSaveButton
        {
            get
            {
                return _driver.FindElement(By.XPath("//div[@class='orangehrm-custom-fields']//button[@type='submit']"));
            }
        }
        public IWebElement Nationality
        {
            get
            {
                return _driver.FindElement(By.XPath("//label[@class='oxd-label' and text()='Nationality']/parent::div/following-sibling::div//div[@class='oxd-select-text-input']"));
            }
        }

        public IWebElement MartialStatus
        {
            get
            {
                return _driver.FindElement(By.XPath("//label[@class='oxd-label' and text()='Marital Status']/parent::div/following-sibling::div//div[@class='oxd-select-text-input']"));
            }
        }
        
        public IWebElement NationalityOptions(string country)
        {
            return _driver.FindElement(By.XPath("//div[@role='option']//span[text()='"+ country +"']"));
        }

        public IWebElement MartialStatusOptions(string martialStatus)
        {
            return _driver.FindElement(By.XPath("//div[@class='oxd-select-dropdown --positon-bottom']/div/span[text()='"+ martialStatus + "']"));
        }

        public IWebElement CustomerBloodTypeOptions(string bloodType)
        {
            return _driver.FindElement(By.XPath("//div[@class='oxd-select-dropdown --positon-bottom']/div/span[text()='" + bloodType + "']"));
        }

        public IWebElement LicenseExpireCalenderButton
        {
            get
            {
                return _driver.FindElement(By.XPath("//label[text()='License Expiry Date']/ancestor::div[@class='oxd-input-group oxd-input-field-bottom-space']//i[@class='oxd-icon bi-calendar oxd-date-input-icon']"));
            }
        }

        public IWebElement DateOfBirthCalenderButton
        {
            get
            {
                return _driver.FindElement(By.XPath("//label[text()='Date of Birth']/ancestor::div[@class='oxd-input-group oxd-input-field-bottom-space']//i[@class='oxd-icon bi-calendar oxd-date-input-icon']"));
            }
        }

        public IWebElement CalenderYearDropdown
        {
            get
            {
                return _driver.FindElement(By.XPath("//li[@class='oxd-calendar-selector-year']"));
            }
        }

        public IWebElement SpecificYearInCalender(int year)
        {
            return _driver.FindElement(By.XPath("//li[@class='oxd-calendar-dropdown--option' and text()='"+ year + "']"));
        }

        public IWebElement CalanderMonthDropdown
        {
            get
            {
                return _driver.FindElement(By.XPath("//div[@class='oxd-calendar-selector-month-selected']"));
            }
        }
        public IWebElement SpecficMonthInCalender(string month)
        {
            return _driver.FindElement(By.XPath("//li[@class='oxd-calendar-dropdown--option' and text() = '"+ month + "']"));
        }

        public IWebElement SpecificDayInCalender(int day)
        {
            return _driver.FindElement(By.XPath("//div[@class='oxd-calendar-date' and text() = '"+ day + "']"));
        }

        public IWebElement BloodTypeDropdown
        {
            get
            {
                return _driver.FindElement(By.XPath("//label[@class='oxd-label' and text()='Blood Type']/parent::div/following-sibling::div//div[@class='oxd-select-text-input']"));
            }
        }

        public IWebElement TestFieldTextBox
        {
            get
            {
                return _driver.FindElement(By.XPath("//label[text()='Test_Field']/ancestor::div[@class='oxd-input-group oxd-input-field-bottom-space']//input[@class='oxd-input oxd-input--active']"));
            }
        }

        public IWebElement EmployeeIDNumber
        {
            get
            {
                return _driver.FindElement(By.XPath("//label[text()='Employee Id']/ancestor::div[@class='oxd-input-group oxd-input-field-bottom-space']//input[@class='oxd-input oxd-input--active']"));
            }
        }

        public IWebElement OtherIDNumber
        {
            get
            {
                return _driver.FindElement(By.XPath("//label[text()='Other Id']/ancestor::div[@class='oxd-input-group oxd-input-field-bottom-space']//input[@class='oxd-input oxd-input--active']"));
            }
        }

        public IWebElement EnterAnyTextBox(string textBoxName)
        {
            return _driver.FindElement(By.XPath("//label[contains(text(),'"+ textBoxName + "')]/ancestor::div[@class='oxd-input-group oxd-input-field-bottom-space']//input[@class='oxd-input oxd-input--active']"));
        }

        public IWebElement GenderRadioButton(string gender)
        {
            return _driver.FindElement(By.XPath("//label[contains(text(),'Gender')]/ancestor::div[@class='oxd-input-group']//label[text()='" + gender + "']"));
        }

        //Employee Contact details page



    }
}
