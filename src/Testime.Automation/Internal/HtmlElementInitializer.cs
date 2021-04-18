using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Testime.Automation.Attributes;
using Testime.Automation.Elements;
using Testime.Automation.Exceptions;

namespace Testime.Automation.Internal
{
    internal static class HtmlElementInitializer
    {
        public static void InitializeContainer(IHtmlContainer container, ISearchContext context, RemoteWebDriver driver)
        {
            var fieldsToLocators = container.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(e => e.GetCustomAttributes().OfType<LocatorAttribute>().Any())
                .ToDictionary(k => k, v => v.GetCustomAttributes().OfType<LocatorAttribute>().First());

            var exceptions = new List<Exception>();

            foreach (var field in fieldsToLocators)
            {
                try
                {
                    var locator = field.Value.Locate();

                    if (field.Key.FieldType.IsGenericType && typeof(List<>).IsAssignableFrom(field.Key.FieldType.GetGenericTypeDefinition()))
                    {
                        var webElements = context.FindElements(locator);

                        var listType = typeof(List<>);
                        var genericArgs = field.Key.FieldType.GetGenericArguments();
                        var concreteType = listType.MakeGenericType(genericArgs);
                        var list = (IList)Activator.CreateInstance(concreteType);

                        foreach (var webElement in webElements)
                        {
                            var element = BuildElement(field.Key, field.Key.FieldType.GetGenericArguments()[0], webElement, driver);
                            list.Add(element);
                        }
                        field.Key.SetValue(container, list);
                    }
                    else if (typeof(HtmlElement).IsAssignableFrom(field.Key.FieldType))
                    {
                        var webElement = context.FindElement(locator);
                        var element = BuildElement(field.Key, field.Key.FieldType, webElement, driver);
                        field.Key.SetValue(container, element);
                    }
                }
                catch (Exception innerException)
                {
                    exceptions.Add(new FieldInitializationException(field.Key, innerException));
                }
            }

            if (exceptions.Any())
            {
                throw new PageInitializationException(container.GetType().Name, exceptions);
            }
        }

        private static HtmlElement BuildElement(FieldInfo field, Type fieldType, IWebElement webElement, RemoteWebDriver driver)
        {
            var constraints = fieldType.GetCustomAttributes<TagConstraintAttribute>().ToList();
            if (constraints.Any() && !constraints.Any(e => e.Matches(webElement)))
            {
                throw new TagContraintFailureException(field, constraints.Select(e => e.Contraint).ToArray());
            }

            var element = (HtmlElement)Activator.CreateInstance(fieldType);
            element.Initialize(driver, webElement);
            return element;
        }
    }
}
