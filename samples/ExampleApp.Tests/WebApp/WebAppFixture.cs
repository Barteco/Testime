using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Testime.Automation.Web;

namespace ExampleApp.Tests.WebApp
{
    public class WebAppFixture
    {
        private WebApplicationSettings _settings;
        private IHost _host;

        public WebAppFixture()
        {
            _settings = new WebApplicationSettings
            {
                Browser = WebBrowser.Chrome,
                RunMode = RunMode.Headless
            };

            _host = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls(_settings.Url);
                })
                .Build();
        }

        public MyExampleApp LaunchApp()
        {
            return new MyExampleApp(_host, _settings)
                .Start()
                .NavigateUrl(_settings.Url);
        }
    }
}
