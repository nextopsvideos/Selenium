using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited.Generic_Methods
{
    class JavaScript
    {
        #region ScrollDown method untill element found
        public static void ScrollToView(IWebElement element)
        {
            IJavaScriptExecutor js = PropertiesCollection.driver as IJavaScriptExecutor;

            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            // js.ExecuteScript("document.getElementById("element").scrollIntoView();");
        }
        #endregion

        #region ScrollDown method 
        public static void Scroll()
        {
            IJavaScriptExecutor js = PropertiesCollection.driver as IJavaScriptExecutor;

            js.ExecuteScript("window.scroll(0, 800);");

        }
        #endregion

        #region ScrollDown to Bottom method 
        public static void ScrollToBottom()
        {
            IJavaScriptExecutor js = PropertiesCollection.driver as IJavaScriptExecutor;

            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");

        }
        #endregion

        #region ScrollUp to Top method 
        public static void ScrollToTop()
        {
            IJavaScriptExecutor js = PropertiesCollection.driver as IJavaScriptExecutor;

            js.ExecuteScript("window.scroll(0, 0);");

        }
        #endregion

        #region Mouse Hover method
        public static void Hover(IWebElement element)
        {
            String strJavaScript = "var element = arguments[0];"
                                            + "var mouseEventObj = document.createEvent('MouseEvents');"
                                            + "mouseEventObj.initEvent( 'mouseover', true, true );"
                                            + "element.dispatchEvent(mouseEventObj);";
            IJavaScriptExecutor js = PropertiesCollection.driver as IJavaScriptExecutor;
            js.ExecuteScript(strJavaScript, element);

        }
        #endregion


    }
}
