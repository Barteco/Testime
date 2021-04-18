using Microsoft.Extensions.Hosting;
using Testime.Automation.Web;

namespace ExampleApp.Tests.WebApp
{
    public class MyExampleApp : WebApplication<MyExampleApp>
    {
        public MyExampleApp(IHost host, WebApplicationSettings settings = null) : base(host, settings)
        {
        }
    }
}
