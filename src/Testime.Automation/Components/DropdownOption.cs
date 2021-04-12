namespace Testime.Automation.Components
{
    public class DropdownOption : Component
    {
        public string Value => Attribute("value");
        public string Text => Self.Text;
        public bool IsSelected => Self.Selected;

        public void Select()
        {
            Self.Click();
        }
    }
}