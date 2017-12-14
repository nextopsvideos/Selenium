using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartsUnlimited.Generic_Methods;
using PartsUnlimited.POM;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium;
using System.Data;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Web.Hosting;

namespace PartsUnlimited.Script
{
    [TestFixture]
    class LoginPage : Base_Class
    {
        
        #region After Class Method
        [TearDown]
        public void CloseBrowser()
        {
            //Close the browser
            Base_Class.CleanUp();
        }
        #endregion
        
        #region Test Scenario 1: Login to the application
        [TestCaseSource(typeof(Base_Class), "BrowserToRunWith")]
        [Test]
        public void Verify_Login(string browserName)
        {
            NavigateToHomePage(browserName);

            //DataTable rCnt = Excel_Library.GetNumberOfRows(HostingEnvironment.MapPath(@".\Login_Credentials.xlsx", "Sheet1"));

            string email = "Administrator@test.com";//Convert.ToString(rCnt.Rows[0]["Email"]);
            string password = "YouShouldChangeThisPassword1!";//Convert.ToString(rCnt.Rows[0]["Password"]);
            
            //wait
            Base_Class.Wait();
            //Click on Login button 
            PropertiesCollection.LoginObject.clickLoginBtn();

            //wait
            Base_Class.Wait();
            //Enter Email ID from excel
            PropertiesCollection.LoginObject.Type_Email(email);
            //Enter Password from excel
            PropertiesCollection.LoginObject.Type_Password(password);

            Base_Class.Wait();
            //Click on Login button            
            PropertiesCollection.LoginObject.clickLoginOnPage();

            //Displays when there is no validation message
            Console.WriteLine(" User logged into 'PartsUnlimited' application succesfully. ");

            //wait
            //Base_Class.Wait();
            //Click on Profile field
            //PropertiesCollection.LoginObject.clickProfile();

            //wait
            //Base_Class.Wait();
            //Click on Manage User link
            //PropertiesCollection.LoginObject.clickManageUser();

            //wait
            //Base_Class.Wait();
            
            //Get the logged in user email id
            //String Username = PropertiesCollection.driver.FindElement(By.XPath("//dd[contains(text(),'" + UserName + "')]")).Text;
            //Console.WriteLine("Logged In Email ID is : " + Username);

        }
        #endregion

        #region Test Scenario 2: Logout from the application
        [TestCaseSource(typeof(Base_Class), "BrowserToRunWith")]
        [Test]
        public void Verify_Logout(string browserName)
        {
            NavigateToHomePage(browserName);

            // DataTable rCnt = Excel_Library.GetNumberOfRows(@"C:\Users\sriramdasbalaji\Source\Repos\Selenium\test\PartsUnlimited.SeleniumTests\Excel_Files\Login_Credentials.xlsx", "Sheet1");

            string email = "Administrator@test.com";//Convert.ToString(rCnt.Rows[0]["Email"]);
            string password = "YouShouldChangeThisPassword1!";//Convert.ToString(rCnt.Rows[0]["Password"]);


            //wait
            Base_Class.Wait();
            //Click on Login button 
            PropertiesCollection.LoginObject.clickLoginBtn();

            //wait
            Base_Class.Wait();
            //Enter Email ID from excel
            PropertiesCollection.LoginObject.Type_Email(email);            
            //Enter Password from excel
            PropertiesCollection.LoginObject.Type_Password(password);            
            //Click on Login button            
            PropertiesCollection.LoginObject.clickLoginOnPage();

            //wait
            Base_Class.Wait();
            //Click on Profile field
            PropertiesCollection.LoginObject.clickProfile();

            //wait
            Base_Class.Wait();
            //Click on Logout button
            PropertiesCollection.LoginObject.clickLogOffBtn();

            //Displays when there is no validation message
            Console.WriteLine(" User logged out from 'PartsUnlimited' application succesfully. ");

        }

        #endregion

    }
}
