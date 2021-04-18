using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("table")]
    public class Table : HtmlElement
    {
        public List<TableRow> Headers => FindElements<TableRow>(By.XPath("./thead/tr")).ToList();

        public List<TableRow> Rows => FindElements<TableRow>(By.XPath("./tbody/tr")).ToList();
    }
}
