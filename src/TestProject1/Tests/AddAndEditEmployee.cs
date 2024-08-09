using PageObjectModel.Flows;
using PageObjectModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Tests
{
    public class AddAndEditEmployee:TestBase
    {
        [Test, Category("Smoke"), Category("Employee")]
        public void AddEmployeeToApp()
        {
            PIMPage pIMPage = new PIMPage(driver);
            PIMFlow pIMFlow = new PIMFlow(pIMPage);

            pIMFlow.ClickPIMMenu();
            pIMFlow.ClickAddEmployeeMenuButton();
            pIMFlow.EnterUserFullName("Vishal", "Pujari");
            pIMFlow.ClickSaveButton();
            pIMFlow.EnterEmployeeID();
            pIMFlow.EnterOtherID(12345);
            pIMFlow.EnterDriversLicenseNumber(98765);
            pIMFlow.SelectLicenseExpiryDate(2005, 6, 15);
            pIMFlow.SelectNationalityDropdown("Indian");
            pIMFlow.SelectMartialStatusDropdown("Married");
            pIMFlow.SelectDateOfBirth(1991, 6, 9);
            pIMFlow.SelectGenderRadioButton("male");
            pIMFlow.SelectBloodTypeDropdown("a-");
            pIMFlow.EnterTestFieldText("random text");
            pIMFlow.ClickCustomFieldSaveButton();

        }
    }
}
