using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Testime.Automation.Attributes;
using Testime.Automation.Internal;
using Testime.Automation.Waiting;

namespace Testime.Automation.Components
{
    public abstract class Page
    {
        public string BrowserTitle => _driver.Title;
        public Wait Wait => new (_driver);

        private RemoteWebDriver _driver;

        public Bitmap TakeScreenshot()
        {
            return new ScreenshotActions(_driver).TakePageScreenshot();
        }

        public TComponent FindComponent<TComponent>(By by) where TComponent : Component, new()
        {
            return _driver.FindComponent<TComponent>(_driver, by);
        }

        public IEnumerable<TComponent> FindComponents<TComponent>(By by) where TComponent : Component, new()
        {
            return _driver.FindComponents<TComponent>(_driver, by);
        }

        internal void Initialize(RemoteWebDriver driver)
        {
            _driver = driver;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            var fieldsToLocators = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(e => e.GetCustomAttributes().OfType<LocatorAttribute>().Any())
                .ToDictionary(k => k, v => v.GetCustomAttributes().OfType<LocatorAttribute>().First());

            foreach (var field in fieldsToLocators)
            {
                try
                {
                    var webElement = field.Value.Initialize(_driver);

                    if (typeof(Component).IsAssignableFrom(field.Key.FieldType))
                    {
                        var component = (Component)Activator.CreateInstance(field.Key.FieldType);
                        component.Initialize(_driver, webElement);

                        field.Key.SetValue(this, component);
                    }

                    if (typeof(Block).IsAssignableFrom(field.Key.FieldType))
                    {
                        var fragment = (Block)Activator.CreateInstance(field.Key.FieldType);
                        fragment.Initialize(_driver, webElement);

                        field.Key.SetValue(this, fragment);
                    }
                }
                catch (Exception innerException)
                {
                    throw new InvalidOperationException($"Page initialization failed for member '{field.Key.Name}'", innerException);
                }
            }
        }
    }
}
