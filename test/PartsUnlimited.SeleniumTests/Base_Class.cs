using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using PartsUnlimited.POM;

namespace PartsUnlimited
{
    class Base_Class
    {
        static string Base_Url = "http://localhost:82/";
        
        public static IEnumerable<string> BrowserToRunWith()
        {
            string[] browsers = { "Chrome", "FireFox" };

            foreach (string b in browsers)
            {
                yield return b;
            }

        }

        #region IniTialize Method
        public void NavigateToHomePage(string browserName)
        {
            
            if (browserName.Equals("Chrome"))
            {
               
               ChromeOptions options = new ChromeOptions();
               options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
               PropertiesCollection.driver = new ChromeDriver(options);
            }

            //else if (browserName.Equals("IE"))
            //{
            //    PropertiesCollection.driver = new InternetExplorerDriver();
            //}

            else
            {
                
                //Instantiating geckodriver for selenium version
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                service.FirefoxBinaryPath = "C:\\Program Files\\Mozilla Firefox\\firefox.exe";

                PropertiesCollection.driver = new FirefoxDriver(service); // Initialize firefox driver
            }

            PropertiesCollection.driver.Navigate().GoToUrl(Base_Url);

            PropertiesCollection.driver.Manage().Window.Maximize();
            
            //wait
            Thread.Sleep(3000);

            //Initializing the page objects by calling its reference
            PropertiesCollection.LoginObject = new LoginPageObjects();
            PropertiesCollection.CartPageObjects = new CartPageObjects();
            PropertiesCollection.LoginObject = new LoginPageObjects();
        }
        #endregion

        #region CleanUp Method
        public static void CleanUp()
        {
            PropertiesCollection.driver.Quit(); // Destroy the web driver instance(Close all the windows).    
        }
        #endregion

        #region Implicit Wait Method
        public static void Wait()
        {
            //PropertiesCollection.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5000));
            Thread.Sleep(3000);
        }
        #endregion

        #region Verify Validations
        public static IWebElement VerifyValidation(IWebElement errorMessage)
        {
            if (errorMessage.Displayed)
                Console.WriteLine(errorMessage.Text); //Display Validation text if found displayed
            else
                Console.WriteLine("No validation message found.");

            return errorMessage;
        }
        #endregion

    }
}
