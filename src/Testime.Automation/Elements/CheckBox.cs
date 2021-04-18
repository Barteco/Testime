using OpenQA.Selenium;
using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("input", "checkbox")]
    public class CheckBox : HtmlElement
    {
        public bool Checked
        {
            get => Self.Selected;
        }

        public bool Disabled => !Self.Enabled;

        public void Check()
        {
            if (!Checked)
            {
                SendKeys(Keys.Space);
            }
        }

        public void Uncheck()
        {
            if (Checked)
            {
                SendKeys(Keys.Space);
            }
        }

        public void Toggle()
        {
            SendKeys(Keys.Space);
        }
    }
}