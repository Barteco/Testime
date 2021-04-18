using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("img")]
    public class Image : HtmlElement
    {
        public string Source => Attribute("src");
    }
}
