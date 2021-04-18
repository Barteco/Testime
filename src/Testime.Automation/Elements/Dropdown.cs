using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("select")]
    public class Dropdown : HtmlElement
    {
        private SelectElement SelectHelper => new(Self);

        public DropdownOption Selected => Options.FirstOrDefault(e => e.IsSelected);

        public List<DropdownOption> Options => FindElements<DropdownOption>(By.TagName("option")).Select(e => e.AttachTo(this)).ToList();

        public void SelectValue(string value)
        {
            SelectHelper.SelectByValue(value);
        }
    }
}
