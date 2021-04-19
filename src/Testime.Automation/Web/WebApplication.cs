using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using OpenQA.Selenium.Remote;
using System;
using Testime.Automation.Elements;
using Testime.Automation.Internal;
using Testime.Automation.Waiting;

namespace Testime.Automation.Web
{
    public abstract class WebApplication<TApp> : IDisposable where TApp : WebApplication<TApp>
    {
        public Wait Wait => new(_driver);

        private RemoteWebDriver _driver;
        private readonly IHost _host;
        private readonly WebApplicationSettings _settings;

        public Uri Url => new(_settings.Url);

        protected WebApplication(IHost host, WebApplicationSettings settings = null)
        {
            _settings = settings ?? WebApplicationSettings.Default;
            _driver = WebDriverFactory.CreateDriver(_settings);
            _host = host;
            _host?.Start();
        }

        public TApp OpenDefaultPage()
        {
            EnsureRunning();
            _driver.Navigate().GoToUrl(_settings.Url);
            return (TApp)this;
        }

        public TPage OpenPage<TPage>() where TPage : HtmlPage, new()
        {
            EnsureRunning();
            Wait.UntilDocumentReady();

            var page = new TPage();
            page.Initialize(_driver);
            return page;
        }

        public TPage NavigatePage<TPage>(string url) where TPage : HtmlPage, new()
        {
            EnsureRunning();
            _driver.Navigate().GoToUrl($"{_settings.Url.TrimEnd('/')}/{url.TrimStart('/')}");
            return OpenPage<TPage>();
        }

        public void Dispose()
        {
            _driver?.Quit();
            _host?.StopAsync().Wait();
        }

        private void EnsureRunning()
        {
            if (_host is null || _driver is null)
            {
                throw new InvalidOperationException("Web application is not running");
            }
        }
    }
}
