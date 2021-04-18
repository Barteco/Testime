using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
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

        public Uri Url => new (_settings.Url);

        protected WebApplication(IHost host, WebApplicationSettings settings = null)
        {
            _host = host;
            _settings = settings ?? WebApplicationSettings.Default;
        }

        public TApp Start()
        {
            StartHost();
            StartDriver();

            return (TApp) this;
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

        public TApp NavigateUrl(string url)
        {
            EnsureRunning();
            _driver.Navigate().GoToUrl(url);
            return (TApp)this;
        }

        public void Dispose()
        {
            _driver?.Quit();
            _host?.StopAsync().Wait();
        }

        private void StartHost()
        {
            _host?.Start();
        }

        private void StartDriver()
        {
            _driver = WebDriverFactory.CreateDriver(_settings);

            if (_settings.RunMode == RunMode.Minimized)
                _driver.Manage().Window.Minimize();

            if (_settings.RunMode == RunMode.Maximized)
                _driver.Manage().Window.Maximize();
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
