using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Testime.Automation.Components
{
    public class TableRow : Component
    {
        public List<TableCell> Cells => FindComponents<TableCell>(By.XPath("./td | ./th")).ToList();
    }
}