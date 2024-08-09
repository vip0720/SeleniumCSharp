using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Flows
{
    public class PIMFlow
    {
        private PIMPage _page;

        public PIMFlow(PIMPage page)
        {
            _page = page;
        }
        public void ClickPIMMenu()
        {
            _page.PIMMenu.Click();
        }
        public void ClickAddEmployeeInEmployeeListPageButton()
        {
            _page.AddEmployeeButtonEmployeeListPage.Click();
        }

        public void ClickEmployeeListMenuButton()
        {
            _page.EmployeeListMenuButton.Click();
        }

        public void ClickAddEmployeeMenuButton()
        {
            _page.AddEmployeeMenuButton.Click();
        }

        public void ClickReportsMenuButton()
        {
            _page.ReportsMenuButton.Click();
        }

        public void ClickPersonalDetailsLink()
        {
            _page.PersonalDetailsLink.Click();
        }

        public void ClickContactDetailsLink()
        {
            _page.ContactDetailsLink.Click();
        }
        public void ClickEmergencyContactsLink()
        {
            _page.EmergencyContactsLink.Click();
        }
        public void ClickDependentsLink()
        {
            _page.DependentsLink.Click();
        }
        public void ClickImmigrationLink()
        {
            _page.ImmigrationLink.Click();
        }
        public void ClickJobLink()
        {
            _page.JobLink.Click();
        }
        public void ClickSalaryLink()
        {
            _page.SalaryLink.Click();
        }
        public void ClickTaxExemptionsLink()
        {
            _page.TaxExemptionsLink.Click();
        }
        public void ClickReportToLink()
        {
            _page.ReportToLink.Click();
        }
        public void ClickQualificationLink()
        {
            _page.QualificationsLink.Click();
        }
        public void ClickMembershipLink()
        {
            _page.MembershipsLink.Click();
        }

        // Add employee personal details page

        public void EnterUserFullName(string firstName, string middleName, string lastName)
        {
            _page.EmpFirstName.SendKeys(firstName);
            _page.EmpMiddleName.SendKeys(middleName);
            _page.EmpLastName.SendKeys(lastName);
        }
        public void EnterUserFullName(string firstName, string lastName)
        {
            _page.EmpFirstName.SendKeys(firstName);
            _page.EmpLastName.SendKeys(lastName);
        }
        public void ClickSaveButton()
        {
            _page.SaveButton.Click();
        }

        public void SelectNationalityDropdown(string country)
        {
            _page.Nationality.Click();
            _page.NationalityOptions(country).Click();
        }

        public void SelectMartialStatusDropdown(string status)
        {
            _page.MartialStatus.Click();
            _page.MartialStatusOptions(status).Click();
        }

        /// <summary>
        /// This is calander to select year, month, day for License Expiry Date. 
        /// The year range is from 1970-2023. Value provided should satify this range else default value would be selected
        /// Month range is 1-12. Value provided should satify this range else default value would be selected
        /// Date range is 1-31. Value provided should satify this range else default value would be selected
        /// </summary>
        /// <param name="args">args will be passed when starting this program</param>
        public void SelectLicenseExpiryDate(int year, int month, int day)
        {
            if(year >= 1970 && year <= 2023)
            {
                _page.LicenseExpireCalenderButton.Click();
                _page.CalenderYearDropdown.Click();
                Common.CommonUtility.ActionMoveToElement(_page._driver, _page.OtherIDNumber);
                _page.SpecificYearInCalender(year).Click();
            }
            else
            {
                _page.LicenseExpireCalenderButton.Click();
                _page.CalenderYearDropdown.Click();
                Common.CommonUtility.ActionMoveToElement(_page._driver, _page.OtherIDNumber);
                _page.SpecificYearInCalender(1989).Click();
            }

            Common.CommonUtility.ActionMoveToElement(_page._driver, _page.OtherIDNumber);
            _page.CalanderMonthDropdown.Click();
            Common.CommonUtility.ActionMoveToElement(_page._driver, _page.OtherIDNumber);
            _page.SpecficMonthInCalender(SelectMonth(month)).Click();

            if (month == 1 || month == 3 || month == 5 || month == 7 || month ==8 || month == 10 || month == 12)
            {
                if (day >= 1 && day <= 31)
                {
                    _page.SpecificDayInCalender(day).Click();
                }
                else
                {
                    _page.SpecificDayInCalender(4).Click();
                }
            }
            else if(month == 2)
            {
                if (year % 4 == 0)
                {
                    if (day >= 1 && day <= 29)
                    {
                        _page.SpecificDayInCalender(day).Click();
                    }
                    else
                    {
                        _page.SpecificDayInCalender(4).Click();
                    }
                }
                else
                {
                    if (day >= 1 && day <= 28)
                    {
                        _page.SpecificDayInCalender(day).Click();
                    }
                    else
                    {
                        _page.SpecificDayInCalender(4).Click();
                    }
                }
            }
            else
            {
                if (day >= 1 && day <= 30)
                {
                    _page.SpecificDayInCalender(day).Click();
                }
                else
                {
                    _page.SpecificDayInCalender(4).Click();
                }
            }

        }

        public void SelectDateOfBirth(int year, int month, int day)
        {
            if (year >= 1970 && year <= 2023)
            {
                _page.DateOfBirthCalenderButton.Click();
                _page.CalenderYearDropdown.Click();
                Common.CommonUtility.ActionMoveToElement(_page._driver, _page.Nationality);
                _page.SpecificYearInCalender(year).Click();
            }
            else
            {
                _page.DateOfBirthCalenderButton.Click();
                _page.CalenderYearDropdown.Click();
                Common.CommonUtility.ActionMoveToElement(_page._driver, _page.Nationality);
                _page.SpecificYearInCalender(1989).Click();
            }

            _page.CalanderMonthDropdown.Click();
            Common.CommonUtility.ActionMoveToElement(_page._driver, _page.Nationality);
            _page.SpecficMonthInCalender(SelectMonth(month)).Click();

            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (day >= 1 && day <= 31)
                {
                    _page.SpecificDayInCalender(day).Click();
                }
                else
                {
                    _page.SpecificDayInCalender(4).Click();
                }
            }
            else if (month == 2)
            {
                if (year % 4 == 0)
                {
                    if (day >= 1 & day <= 29)
                    {
                        _page.SpecificDayInCalender(day).Click();
                    }
                    else
                    {
                        _page.SpecificDayInCalender(4).Click();
                    }
                }
                else
                {
                    if (day >= 1 && day <= 28)
                    {
                        _page.SpecificDayInCalender(day).Click();
                    }
                    else
                    {
                        _page.SpecificDayInCalender(4).Click();
                    }
                }
            }
            else
            {
                if (day >= 1 && day <= 30)
                {
                    _page.SpecificDayInCalender(day).Click();
                }
                else
                {
                    _page.SpecificDayInCalender(4).Click();
                }
            }
        }

        private string SelectMonth(int month)
        {
            switch(month)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "March";
            }
        }

        public void EnterDriversLicenseNumber(int licenseNumber)
        {
            string text = licenseNumber.ToString();
            _page.EnterAnyTextBox("License Number").SendKeys(text);
        }

        public void SelectBloodTypeDropdown(string bloodType)
        {
            bloodType = bloodType.ToUpper();
            _page.BloodTypeDropdown.Click();
            _page.CustomerBloodTypeOptions(bloodType).Click();
        }

        public void EnterTestFieldText(string text)
        {
            _page.TestFieldTextBox.SendKeys(text);
        }

        public void EnterEmployeeID()
        {
            _page.EmployeeIDNumber.SendKeys("0101");
        }
        public void EnterOtherID(int inputText)
        {
            string text = inputText.ToString();
            _page.OtherIDNumber.SendKeys(text);
        }

        public void EnterValueInAnyTextBox(string fieldName, string fieldValue)
        {
            _page.EnterAnyTextBox(fieldName).SendKeys(fieldValue);
        }

        public void SelectGenderRadioButton(string gender)
        {
            gender = gender.ToLower();
            if(gender == "male")
            {
                _page.GenderRadioButton("Male").Click();
            }
            else
            {
                _page.GenderRadioButton("Female").Click();
            }
        }

        public void ClickCustomFieldSaveButton()
        {
            _page.CustomFieldsSaveButton.Click();
        }

        //Employee Contact details page



    }
}
