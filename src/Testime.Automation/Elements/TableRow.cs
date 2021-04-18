using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Testime.Automation.Attributes;

namespace Testime.Automation.Elements
{
    [TagConstraint("tr")]
    public class TableRow : HtmlElement
    {
        public List<TableCell> Cells => FindElements<TableCell>(By.XPath("./td | ./th")).ToList();
    }
}