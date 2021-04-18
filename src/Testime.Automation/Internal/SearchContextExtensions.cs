using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;
using Testime.Automation.Elements;

namespace Testime.Automation.Internal
{
    internal static class SearchContextExtensions
    {
        public static TElement FindElement<TElement>(this ISearchContext context, RemoteWebDriver driver, By by) where TElement : HtmlElement, new()
        {
            var element = new TElement();
            element.Initialize(driver, context.FindElement(by));
            return element;
        }

        public static IEnumerable<TElement> FindElements<TElement>(this ISearchContext context, RemoteWebDriver driver, By by) where TElement : HtmlElement, new()
        {
            return context.FindElements(by).Select(e =>
            {
                var element = new TElement();
                element.Initialize(driver, e);
                return element;
            });
        }
    }
}
