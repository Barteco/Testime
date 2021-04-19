using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Testime.Automation.Web;

namespace ExampleApp.Tests.WebApp
{
    public class ExampleApplicationFixture : IDisposable
    {
        private readonly ExampleApplication _app;
        private readonly IHost _host;

        public ExampleApplicationFixture()
        {
            var settings = new WebApplicationSettings
            {
                Browser = WebBrowser.Chrome,
                RunMode = RunMode.Headless
            };

            _host = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls(settings.Url);
                })
                .Build();

            _host.Start();

            _app = new ExampleApplication(settings);
        }

        public ExampleApplication LaunchApp()
        {
            return _app.OpenDefaultPage();
        }

        public void Dispose()
        {
            _host?.StopAsync().Wait();
            _app?.Dispose();
        }
    }
}
