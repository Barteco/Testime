using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("ul")]
    [TagConstraint("ol")]
    public class List : HtmlElement
    {
        public List<ListItem> Items => FindElements<ListItem>(By.TagName("li")).ToList();
    }
}
