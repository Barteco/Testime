using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Testime.Automation.Web;

namespace ExampleApp.Tests.WebApp
{
    public class WebAppFixture : IDisposable
    {
        private readonly MyExampleApp _app;

        public WebAppFixture()
        {
            var settings = new WebApplicationSettings
            {
                Browser = WebBrowser.Chrome,
                RunMode = RunMode.Headless
            };

            var host = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls(settings.Url);
                })
                .Build();

            _app = new MyExampleApp(host, settings);
        }

        public MyExampleApp LaunchApp()
        {
            return _app.OpenDefaultPage();
        }

        public void Dispose()
        {
            _app?.Dispose();
        }
    }
}
