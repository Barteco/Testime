using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("p")]
    public class Paragraph : HtmlElement
    {
        public string Text => Self.Text;
    }
}