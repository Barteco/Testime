using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("input", "button")]
    [TagConstraint("input", "submit")]
    [TagConstraint("button")]
    public class Button : HtmlElement
    {
        public string Text => Self.TagName == "button" ? Self.Text : Attribute("value");

        public bool Disabled => !Self.Enabled;
    }
}
