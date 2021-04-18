using OpenQA.Selenium.Remote;
using System;
using System.Drawing;
using System.IO;
using Testime.Automation.Elements;

namespace Testime.Automation.Internal
{
    internal class ScreenshotActions
    {
        private readonly RemoteWebDriver _driver;

        public ScreenshotActions(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        public Bitmap TakePageScreenshot()
        {
            var rawScreenshot = _driver.GetScreenshot().AsByteArray;

            using var memoryStream = new MemoryStream(rawScreenshot);

            return new Bitmap(memoryStream);
        }

        public Bitmap TakeElementScreenshot(HtmlElement element, int margin = 0)
        {
            element.ScrollTo(margin);

            var elementLocation = element.Location;
            var elementSize = element.Size;
            var scrollPosition = _driver.GetScrollPosition();
            var rawScreenshot = _driver.GetScreenshot().AsByteArray;

            using (var memoryStream = new MemoryStream(rawScreenshot))
            using (var windowScreenshot = new Bitmap(memoryStream))
            {
                var startX = elementLocation.X - scrollPosition.X - margin;
                var startY = elementLocation.Y - scrollPosition.Y - margin;
                var endX = startX + elementSize.Width + 2 * margin;
                var endY = startY + elementSize.Height + 2 * margin;

                startX = Math.Clamp(startX, 0, windowScreenshot.Width);
                endX = Math.Clamp(endX, 0, windowScreenshot.Width);
                startY = Math.Clamp(startY, 0, windowScreenshot.Height);
                endY = Math.Clamp(endY, 0, windowScreenshot.Height);

                var screenshotStart = new Point(startX, startY);
                var screenshotSize = new Size(endX - startX, endY - startY);
                var screenshotBounds = new Rectangle(screenshotStart, screenshotSize);

                return windowScreenshot.Clone(screenshotBounds, windowScreenshot.PixelFormat);
            }
        }
    }
}