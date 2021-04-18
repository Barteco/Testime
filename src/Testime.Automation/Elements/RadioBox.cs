using OpenQA.Selenium;
using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("input", "radio")]
    public class RadioBox : HtmlElement
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