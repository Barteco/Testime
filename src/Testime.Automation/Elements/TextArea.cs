using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("textarea")]
    public class TextArea : HtmlElement
    {
        public string Value => Attribute("value");

        public string Placeholder => Attribute("placeholder");

        public int? MaxLength => TryGetIntegerAttribute("maxlength");

        public int? Rows => TryGetIntegerAttribute("rows");

        public int? Cols => TryGetIntegerAttribute("cols");

        public bool Disabled => !Self.Enabled;

        public new void SetValue(string value)
        {
            base.SetValue(value);
        }
    }
}