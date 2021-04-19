using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using Testime.Automation.Web;

namespace Testime.Automation.Internal
{
    internal static class WebDriverFactory
    {
        public static RemoteWebDriver CreateDriver(WebApplicationSettings settings)
        {
            var driver = CreateDriverByBrowser(settings);

            if (settings.RunMode == RunMode.Minimized)
            {
                driver.Manage().Window.Minimize();
            }

            if (settings.RunMode == RunMode.Maximized)
            {
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        private static RemoteWebDriver CreateDriverByBrowser(WebApplicationSettings settings)
        {
            switch (settings.Browser)
            {
                case WebBrowser.Firefox:
                {
                    var options = new FirefoxOptions
                    {
                        AcceptInsecureCertificates = settings.AcceptInsecureCertificates
                    };

                    if (settings.RunMode == RunMode.Headless)
                    {
                        options.AddArgument("--headless");
                    }

                    return new FirefoxDriver(options);
                }

                case WebBrowser.Chrome:
                {
                    var options = new ChromeOptions
                    {
                        AcceptInsecureCertificates = settings.AcceptInsecureCertificates
                    };

                    if (settings.RunMode == RunMode.Headless)
                    {
                        options.AddArgument("--headless");
                    }
                    else if (settings.RunMode == RunMode.Maximized)
                    {
                        options.AddArgument("--start-maximized");
                    }
                    return new ChromeDriver(options);
                }

                default:
                {
                    throw new Exception("Unsupported browser");
                }
            }
        }
    }
}
