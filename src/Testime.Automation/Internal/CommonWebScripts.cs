using System.Drawing;
using OpenQA.Selenium;

namespace Testime.Automation.Internal
{
    internal static class CommonWebScripts
    {
        public static bool IsDocumentReady(this IJavaScriptExecutor jsDriver)
        {
            return jsDriver.ExecuteScript("return document.readyState").Equals("complete");
        }

        public static void ScrollTo(this IJavaScriptExecutor jsDriver, IWebElement element, int margin = 0)
        {
            jsDriver.ExecuteScript($"arguments[0].scrollIntoView(true); window.scrollBy({-margin}, {-margin});", element);
        }

        public static Point GetScrollPosition(this IJavaScriptExecutor jsDriver)
        {
            var x = (long) jsDriver.ExecuteScript("return window.pageXOffset;");
            var y = (long) jsDriver.ExecuteScript("return window.pageYOffset;");
            return new Point((int)x, (int)y);
        }
    }
}