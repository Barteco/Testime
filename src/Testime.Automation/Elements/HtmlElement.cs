using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Testime.Automation.Internal;

namespace Testime.Automation.Elements
{
    public class HtmlVirtualElement
    {

    }

    public abstract class HtmlElement
    {
        protected IWebElement Self { get; private set; }

        private RemoteWebDriver _driver;

        public string Id => Attribute("id");
        public string Name => Attribute("name");
        public string Data(string dataAttribute) => Attribute($"data-{dataAttribute}");
        public string Attribute(string attribute) => Self.GetAttribute($"{attribute}");
        public string CssValue(string propertyName) => Self.GetCssValue(propertyName);
        public List<string> ClassList => Attribute("class").Split().ToList();
        public string Tag => Self.TagName;
        public Point Location => Self.Location;
        public Point Center => new (Location.X + (Size.Width / 2), Location.Y + (Size.Height / 2));
        public Size Size => Self.Size;
        public Rectangle Bounds => new (Location, Size);
        public bool Displayed => Self.Displayed;

        public void Click()
        {
            Self.Click();
        }

        public void DoubleClick()
        {
            new Actions(_driver).DoubleClick();
        }

        public virtual void RightClick()
        {
            new Actions(_driver).ContextClick(Self);
        }

        public virtual void DragAndDrop(IWebElement target)
        {
            new Actions(_driver).DragAndDrop(Self, target);
        }

        public virtual void MouseDown()
        {
            new Actions(_driver).ClickAndHold(Self);
        }

        public virtual void MouseUp()
        {
            new Actions(_driver).Release(Self);
        }

        public void ScrollTo(int margin = 0)
        {
            _driver.ScrollTo(Self, margin);
        }

        public Bitmap TakeScreenshot(int margin = 0)
        {
            return new ScreenshotActions(_driver).TakeElementScreenshot(this, margin);
        }

        public TElement FindElement<TElement>(By by) where TElement : HtmlElement, new()
        {
            return Self.FindElement<TElement>(_driver, by);
        }

        public IEnumerable<TElement> FindElements<TElement>(By by) where TElement : HtmlElement, new()
        {
            return Self.FindElements<TElement>(_driver, by);
        }

        protected int? TryGetIntegerAttribute(string attributeName)
        {
            if (int.TryParse(Attribute(attributeName), out var attrValue))
                return attrValue;
            return null;
        }

        protected void Clear()
        {
            Self.Clear();
        }

        protected void SendKeys(string keys)
        {
            Self.SendKeys(keys);
        }

        protected void SetValue(string value)
        {
            Clear();
            SendKeys(value);
        }

        internal void Initialize(RemoteWebDriver driver, IWebElement self)
        {
            _driver = driver;
            Self = self;

            if (this is IHtmlContainer container)
            {
                HtmlElementInitializer.InitializeContainer(container, Self, _driver);
            }
        }
    }
}