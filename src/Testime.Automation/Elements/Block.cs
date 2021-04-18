using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("div")]
    public class Block : HtmlElement, IHtmlContainer
    {
        public string Text => Self.Text;
    }
}