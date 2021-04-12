namespace Testime.Automation.Components
{
    public class TextArea : Component
    {
        public string Value
        {
            get => Attribute("value");
            set => SetValue(value);
        }

        public string Placeholder => Attribute("placeholder");

        public int? MaxLength => TryGetIntegerAttribute("maxlength");

        public bool Disabled => !Self.Enabled;
    }
}