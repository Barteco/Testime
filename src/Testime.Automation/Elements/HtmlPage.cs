using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Drawing;
using Testime.Automation.Internal;
using Testime.Automation.Waiting;

namespace Testime.Automation.Elements
{
    public abstract class HtmlPage : IHtmlContainer
    {
        public string BrowserTitle => _driver.Title;
        public Wait Wait => new (_driver);

        private RemoteWebDriver _driver;

        public Bitmap TakeScreenshot()
        {
            return new ScreenshotActions(_driver).TakePageScreenshot();
        }

        public TElement FindElement<TElement>(By by) where TElement : HtmlElement, new()
        {
            return _driver.FindElement<TElement>(_driver, by);
        }

        public IEnumerable<TElement> FindElements<TElement>(By by) where TElement : HtmlElement, new()
        {
            return _driver.FindElements<TElement>(_driver, by);
        }

        internal void Initialize(RemoteWebDriver driver)
        {
            _driver = driver;
            HtmlElementInitializer.InitializeContainer(this, driver, driver);
        }
    }
}
