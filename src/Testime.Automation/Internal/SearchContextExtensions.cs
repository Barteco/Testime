using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;
using Testime.Automation.Components;

namespace Testime.Automation.Internal
{
    internal static class SearchContextExtensions
    {
        public static TComponent FindComponent<TComponent>(this ISearchContext context, RemoteWebDriver driver, By by) where TComponent : Component, new()
        {
            var component = new TComponent();
            component.Initialize(driver, context.FindElement(by));
            return component;
        }

        public static IEnumerable<TComponent> FindComponents<TComponent>(this ISearchContext context, RemoteWebDriver driver, By by) where TComponent : Component, new()
        {
            return context.FindElements(by).Select(element =>
            {
                var component = new TComponent();
                component.Initialize(driver, element);
                return component;
            });
        }
    }
}
