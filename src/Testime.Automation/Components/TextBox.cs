namespace Testime.Automation.Components
{
    public class TextBox : Component
    {
        public string Value
        {
            get => Attribute("value");
            set => SetValue(value);
        }

        public string Placeholder => Attribute("placeholder");

        public int? MaxLength => TryGetIntegerAttribute("maxlength");

        public int? Rows => TryGetIntegerAttribute("rows");

        public int? Cols => TryGetIntegerAttribute("cols");

        public bool Disabled => !Self.Enabled;
    }
}
