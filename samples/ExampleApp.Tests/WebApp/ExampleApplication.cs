using Testime.Automation.Web;

namespace ExampleApp.Tests.WebApp
{
    public class ExampleApplication : WebApplication<ExampleApplication>
    {
        public ExampleApplication(WebApplicationSettings settings = null) : base(settings)
        {
        }
    }
}
