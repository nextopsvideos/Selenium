using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PartsUnlimited.Generic_Methods;
using PartsUnlimited.POM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited.Script
{
    [TestFixture] //Identifying class as Test class
    class ProductCartPage : Base_Class
    {
        string cartValue;

        //#region Before Class Method  
        //[SetUp] //Identifies a method to be executed each time before a TestMethod/Test is executed
        //public void NavigateToHomePage()
        //{
        //    DataTable rCnt = Excel_Library.GetNumberOfRows(@"C:\Users\Karthee\Desktop\Login_Credentials.xlsx", "Sheet1");

        //    string email = Convert.ToString(rCnt.Rows[0]["Email"]);
        //    string password = Convert.ToString(rCnt.Rows[0]["Password"]);

        //    Base_Class.Initialize(); // Initializing driver
            
        //    //Initialize the page by calling its reference
            
        //}
        //#endregion

        #region After Class Method 
        [TearDown] // Identifies a method to be executed each time after a TestMethod/Test has executed
        public void CloseBrowser()
        {
            Base_Class.CleanUp();
        }
        #endregion

        #region Scenario_1: Add product/s to cart page 
        [TestCaseSource(typeof(Base_Class), "BrowserToRunWith")]
        [Test, Order(1)] //Identifying method as TestCase and specifying the execution order
        public void Verify_AddProductToCart(string browserName)
        {
            NavigateToHomePage(browserName);
            //DataTable rCnt = Excel_Library.GetNumberOfRows(@"C:\Users\Karthee\Desktop\Login_Credentials.xlsx", "Sheet1");
          //  DataTable rCnt = Excel_Library.GetNumberOfRows(@"C:\Users\sriramdasbalaji\Source\Repos\Selenium\test\PartsUnlimited.SeleniumTests\Excel_Files\Login_Credentials.xlsx", "Sheet1");
            string email = "Administrator@test.com";//Convert.ToString(rCnt.Rows[0]["Email"]);
            string password = "YouShouldChangeThisPassword1!";//Convert.ToString(rCnt.Rows[0]["Password"]);


            //------ Login to application ---------------

            //Click on Login icon 
            PropertiesCollection.LoginObject.clickLoginBtn();
            Base_Class.Wait(); //Implicit wait of 3000ms

            //Type in Email ID and Password
            PropertiesCollection.LoginObject.Type_Email(email);
            PropertiesCollection.LoginObject.Type_Password(password);

            //Click on Login button            
            PropertiesCollection.LoginObject.clickLoginOnPage(); Base_Class.Wait();

            //------ Adding product/s to cart page ---------------

            //Scroll till element "Synthetic Engine oil" using Javascript
            IJavaScriptExecutor js = PropertiesCollection.driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scroll(0, 1500);"); Base_Class.Wait(); 

            //Identifying the product and add to cart
            if (PropertiesCollection.CartPageObjects.AlloyRim.Displayed)
            {
                PropertiesCollection.CartPageObjects.Click_AlloyRim(); //Click on item
                Base_Class.Wait();

                PropertiesCollection.CartPageObjects.Click_AddtoCart(); //Click on Add to cart button
                Base_Class.Wait();

                //cartValue = PropertiesCollection.CartPageObjects.cartCount.Text; //Storing the cart-count in var "Cart_Value"

                Console.WriteLine("Items added to cart page. Following are the product details:\n");
                Base_Class.Wait();
                
                //Identifying the number of product/s in cart page 
                IList<IWebElement> summary = PropertiesCollection.driver.FindElements(By.XPath("//div[@class='row']/div[5]/div[1]/strong/a"));
                
                //Displaying the cart summary details
                foreach (var item in summary)
                {
                    Console.WriteLine(item.Text + "\n");
                }
            }
            else
            {
                Console.WriteLine("Search item could not be found.\n");
            }
        }
        #endregion

        #region Scenario_2: Remove product/s from cart page 
        [TestCaseSource(typeof(Base_Class), "BrowserToRunWith")]
        [Test, Order(2)] //Identifying method as TestCase and specifying the execution order
        public void Verify_RemoveProductFromCart(string browserName)
        {
            NavigateToHomePage(browserName);
         //   DataTable rCnt = Excel_Library.GetNumberOfRows(@"C:\Users\sriramdasbalaji\Source\Repos\Selenium\test\PartsUnlimited.SeleniumTests\Excel_Files\Login_Credentials.xlsx", "Sheet1");

            string email = "Administrator@test.com";//Convert.ToString(rCnt.Rows[0]["Email"]);
            string password = "YouShouldChangeThisPassword1!";//Convert.ToString(rCnt.Rows[0]["Password"]);


            //------ Login to application ---------------

            //Click on Login icon 
            PropertiesCollection.LoginObject.clickLoginBtn();
            Base_Class.Wait(); //Implicit wait of 3000ms

            //Type in Email ID and Password
            PropertiesCollection.LoginObject.Type_Email(email);
            PropertiesCollection.LoginObject.Type_Password(password);

            //Click on Login button            
            PropertiesCollection.LoginObject.clickLoginOnPage(); Base_Class.Wait();

            //------ Adding product/s to cart page ---------------

            //Scroll till element "Synthetic Engine oil" is visible using Javascript
            IJavaScriptExecutor js = PropertiesCollection.driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scroll(0, 1500);"); Base_Class.Wait();

            //Identifying the product and add to cart
            if (PropertiesCollection.CartPageObjects.AlloyRim.Displayed)
            {
                PropertiesCollection.CartPageObjects.Click_AlloyRim(); //Click on item
                Base_Class.Wait();

                PropertiesCollection.CartPageObjects.Click_AddtoCart(); //Click on Add to cart button
                Base_Class.Wait();

                //cartValue = PropertiesCollection.CartPageObjects.cartCount.Text; //Storing the cart-count in var "Cart_Value"

                Console.WriteLine("Item/s found in cart page. Cart page Summary:\n");
                Base_Class.Wait();

                //Identifying the number of product/s in cart page and displaying on console
                IList<IWebElement> summary1 = PropertiesCollection.driver.FindElements(By.XPath("//div[@class='row']/div[5]/div[1]/strong/a"));

                foreach (var item in summary1)
                {
                    Console.WriteLine(item.Text + "\n");
                }

                //------ Removing product/s from cart page ---------------
                
                //Removing products from cart page
                IList<IWebElement> summary2 = PropertiesCollection.driver.FindElements(By.XPath("//div[@class='row']/div[6]/a"));

                foreach (var item in summary2)
                {
                    item.Click();
                    Base_Class.Wait();
                }

                //Displaying cart summary post removing products
                Console.WriteLine("\nItem/s removed from cart page. Cart page Summary:\n"); Base_Class.Wait();

                //Verifying empty cart messages
                Base_Class.VerifyValidation(PropertiesCollection.CartPageObjects.emptyCart_msg1); Base_Class.Wait();
                Base_Class.VerifyValidation(PropertiesCollection.CartPageObjects.emptyCart_msg2); Base_Class.Wait();
                
            }
            else
            {
                Console.WriteLine("Search item could not be found.\n");
            }
        }
        #endregion
    }
}