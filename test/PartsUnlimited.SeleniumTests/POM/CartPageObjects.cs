using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace PartsUnlimited.POM
{
    class CartPageObjects
    {
        //Constructor to Initiate page objects
        public CartPageObjects()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        //--------------------------------------------------------------------------------------------
        //Identifying Synthetic Engine Oil image
        [FindsBy(How = How.XPath, Using = "//div[@class='image']/img[@alt='Blue Performance Alloy Rim']")]
        public IWebElement AlloyRim { get; set; }

        //Identifying href-btn Add to Cart
        [FindsBy(How = How.XPath, Using = "//a[@class='btn'][contains(text(), 'Add to Cart')]")]
        public IWebElement addtoCart { get; set; }

        //Identifying Cart-count
        [FindsBy(How = How.Id, Using = "cart-count")]
        public IWebElement cartCount { get; set; }

        //Identifying empty cart messages
        [FindsBy(How = How.Id, Using = "update-message")]
        public IWebElement emptyCart_msg1 { get; set; }

        [FindsBy(How = How.Id, Using = "empty-cart")]
        public IWebElement emptyCart_msg2 { get; set; }

        //--------------------------------------------------------------------------------------------

        //Click on Add to cart button
        public void Click_AddtoCart()
        {
            addtoCart.Click();
        } 
        
        //Click on Synthetic Engine Oil
        public void Click_AlloyRim()
        {
            AlloyRim.Click();
        }

        
    }
}
