using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("a")]
    public class Link : HtmlElement
    {
        public string Destination => Attribute("href");
        public string Target => Attribute("target");
        public string Text => Self.Text;
    }
}
