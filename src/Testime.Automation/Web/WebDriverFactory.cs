using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;

namespace Testime.Automation.Web
{
    internal static class WebDriverFactory
    {
        public static RemoteWebDriver CreateDriver(WebApplicationSettings settings)
        {
            switch (settings.Browser)
            {
                case WebBrowser.Firefox:
                {
                    var options = new FirefoxOptions
                    {
                        BrowserExecutableLocation = GetBinDirectory(),
                        AcceptInsecureCertificates = settings.AcceptInsecureCertificates
                    };

                    if (settings.RunMode == RunMode.Headless)
                    {
                        options.AddArgument("-headless");
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
                    return new ChromeDriver(GetBinDirectory(), options);
                }

                default:
                {
                    throw new Exception("Unsupported browser");
                }
            }
        }

        private static string GetBinDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}
