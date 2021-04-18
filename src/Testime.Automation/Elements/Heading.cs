using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("h1")]
    [TagConstraint("h2")]
    [TagConstraint("h3")]
    [TagConstraint("h4")]
    [TagConstraint("h5")]
    [TagConstraint("h6")]
    public class Heading : HtmlElement
    {
        public string Text => Self.Text;
    }
}
