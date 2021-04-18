using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("option")]
    public class DropdownOption : HtmlElement
    {
        public string Value => Attribute("value");
        public string Text => Self.Text;
        public bool IsSelected => Self.Selected;

        private Dropdown _parent;

        public void Select()
        {
            ((Dropdown)_parent).SelectValue(Value);
        }

        internal DropdownOption AttachTo(Dropdown parent)
        {
            _parent = parent;

            return this;
        }
    }
}