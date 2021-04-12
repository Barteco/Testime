using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using OpenQA.Selenium.Remote;
using System;
using System.Linq;
using System.Threading.Tasks;
using Testime.Automation.Components;
using Testime.Automation.Waiting;

namespace Testime.Automation.Web
{
    public abstract class WebApplication<TApp> : IAsyncDisposable where TApp : WebApplication<TApp>
    {
        public Wait Wait => new(_driver);

        private RemoteWebDriver _driver;
        private readonly IWebHost _host;
        private readonly WebApplicationSettings _settings;
        private string _baseAddress;

        protected WebApplication(IWebHost host, Action<WebApplicationSettings> settingsBuilder)
        {
            _host = host;
            _settings = WebApplicationSettings.Default
                .Apply(settingsBuilder);
        }

        public TApp Launch()
        {
            StartHost();
            StartDriver();

            return (TApp) this;
        }

        public TPage OpenDefaultPage<TPage>() where TPage : Page, new()
        {
            NavigateTo(_baseAddress);
            return OpenPage<TPage>();
        }

        public TPage OpenPage<TPage>() where TPage : Page, new()
        {
            EnsureRunning();

            Wait.UntilDocumentReady();

            var page = new TPage();
            page.Initialize(_driver);
            return page;
        }

        public void NavigateTo(string url)
        {
            EnsureRunning();
            _driver.Navigate().GoToUrl(url);
        }

        public virtual async ValueTask DisposeAsync()
        {
            _driver?.Dispose();
            await _host?.StopAsync();
        }

        private void StartHost()
        {
            _host.Start();
            _baseAddress = _host.ServerFeatures
                .Get<IServerAddressesFeature>()
                .Addresses.First();
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
