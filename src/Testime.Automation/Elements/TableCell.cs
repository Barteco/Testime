using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("td")]
    [TagConstraint("th")]
    public class TableCell : HtmlElement
    {
        public string Text => Self.Text;
    }
}