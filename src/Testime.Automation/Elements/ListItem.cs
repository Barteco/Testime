using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("li")]
    public class ListItem : HtmlElement
    {
        public string Text => Self.Text;
    }
}
