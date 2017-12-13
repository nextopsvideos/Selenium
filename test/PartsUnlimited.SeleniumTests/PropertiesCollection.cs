using OpenQA.Selenium;
using PartsUnlimited.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace PartsUnlimited
{
         //Strongly typed Locators/Element types
        enum PropertyType
        {
            Id,
            Name,
            LinkText,
            PartialLinkText,
            TagName,
            ClassName,
            Css,
            XPath
        }
        class PropertiesCollection
        {
            //Auto Implemented Properties
            public static IWebDriver driver { get; set; }
            public static LoginPageObjects LoginObject { get; set; }
            public static Excel_Library excel { get; set; }
            public static CartPageObjects CartPageObjects { get; set; }
    }

    }

    
