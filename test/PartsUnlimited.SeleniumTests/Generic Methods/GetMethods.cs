using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited.Generic_Methods
{
    class GetMethods
    {
        #region Method to get text from Text Box
        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }
        #endregion
        
        #region Method to get Text from DropDown List
        public static string GetTexFromtDDL(IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }
        #endregion

    }
}
