using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace PartsUnlimited.POM
{
    class LoginPageObjects
    {
        //Constructor to Initiate page objects
        public LoginPageObjects()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        //Identifying the Login button on header 
        [FindsBy(How = How.Id, Using = "login-link")]
        private IWebElement LoginBtn { get; set; }

        //Identifying the Email field
        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement EmailID { get; set; }
        
        //Identifying the Password field
        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement Password { get; set; }

        //Identifying the Login button on Login page
        [FindsBy(How = How.XPath, Using = "//input[@class='btn btn-default']")]
        private IWebElement LoginBtnOnPage { get; set; }

        //Identifying the Validation message
        [FindsBy(How = How.XPath, Using = "//li[contains(text(),'Invalid login attempt.')]")]
        public IWebElement InvalidValMessage { get; set; }

        //Identifying Profile field
        [FindsBy(How = How.XPath, Using = "//a[@id='profile-link']")]
        private IWebElement Profile { get; set; }
        
        //Identifying the Logout button
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Log off')]")]
        private IWebElement LogOffBtn { get; set; }

        //Identifying Manage User link 
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Manage Account')]")]
        private IWebElement ManageUserLink { get; set; }


        //----------------------------------------------------------------------------

        //This is to click on Login button on header
        public void clickLoginBtn()
        {
            LoginBtn.Click();
        }

        //This is to enter Email ID
        public void Type_Email(string Email)
        {
            EmailID.SendKeys(Email);
        }

        //This is to enter Password
        public void Type_Password(string PWD)
        {
            Password.SendKeys(PWD);
        }

        //This is to click on Login button on web page
        public void clickLoginOnPage()
        {
            LoginBtnOnPage.Click();
        }

        //This is to click on Profile field
        public void clickProfile()
        {
            Profile.Click();
        }

        //This is to click on Logout button
        public void clickLogOffBtn()
        {
            LogOffBtn.Click();
        }        

        //This is to click on Manage User link
        public void clickManageUser()
        {
            ManageUserLink.Click();
        }


    }
}
