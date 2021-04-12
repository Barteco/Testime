using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Testime.Automation.Components
{
    public class Table : Component
    {
        public List<TableRow> Headers => FindComponents<TableRow>(By.XPath("./thead/tr")).ToList();

        public List<TableRow> Rows => FindComponents<TableRow>(By.XPath("./tbody/tr")).ToList();
    }
}
