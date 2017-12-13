using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited.Generic_Methods
{
    public static class SetMethods
    {
        //Extended method for entering text in the control
        #region Method to Type in Text
        public static void TypeText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }
        #endregion
        
        #region Method to perform click operation: button, checkbox, options etc.,
        public static void Click(this IWebElement element)
        {
            element.Click();
        }
        #endregion
        
        #region Method to select drop-down control
        public static void SelectDropDown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }
        #endregion

    }
}
