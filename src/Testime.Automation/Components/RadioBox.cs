using OpenQA.Selenium;

namespace Testime.Automation.Components
{
    public class RadioBox : Component
    {
        public bool Checked
        {
            get => Self.Selected;
            set
            {
                if (Checked != value)
                {
                    SendKeys(Keys.Space);
                }
            }
        }

        public bool Disabled => !Self.Enabled;
    }
}