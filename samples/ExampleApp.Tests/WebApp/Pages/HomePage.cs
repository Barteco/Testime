using Testime.Automation.Attributes;
using Testime.Automation.Elements;

namespace ExampleApp.Tests.WebApp.Pages
{
    public class HomePage : HtmlPage
    {
        [Id("greeting")]
        public Heading Greeting;
    }
}
