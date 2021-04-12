using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Testime.Automation.Components
{
    public class Dropdown : Component
    {
        public DropdownOption Selected => Options.FirstOrDefault(e => e.IsSelected);

        public List<DropdownOption> Options => FindComponents<DropdownOption>(By.TagName("option")).ToList();
    }
}
